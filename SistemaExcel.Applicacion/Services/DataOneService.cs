using Serilog;
using SistemaExcel.Applicacion.Mapper.Interfaces;
using SistemaExcel.Applicacion.Services.Interfaces;
using SistemaExcel.Applicacion.Util;
using SistemaExcel.Dominio.Entidades;
using SistemaExcel.Dominio.Model;
using SistemaExcel.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Services
{
    public class DataOneService : IDataOneService
    {
        private readonly IDataOneRepository _dataOneRepository;
        protected IMapear mapeador;
        private readonly ILogger _log;
        public DataOneService(IDataOneRepository dataOneRepository, IMapear mapeador, ILogger log)
        {
            _dataOneRepository = dataOneRepository;
            this.mapeador = mapeador;
            _log = log.ForContext<DataOneService>();
        }

        public async Task<Response<bool>> ActualizarDataOne(List<DataOneModel> model)
        {
            bool resutado = true;
            List<DataOne> dataOne = new List<DataOne>();
            try
            {
                dataOne = mapeador.mapper.Map<List<DataOne>>(model);
                if (dataOne.Count>0)
                {
                    foreach (var item in dataOne)
                    {
                        item.FechaActualizacion = DateTime.Now.ToString();
                    }
                }
                resutado = await _dataOneRepository.ActualizarDataOne(dataOne);
                return Response<bool>.Ok(true, "");
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error ActualizarDataOne");
                return Response<bool>.Error(ex);
            }
            
        }

        public async Task<Response<bool>> CargarDataOne(List<DataOneModel> model)
        {            
            List<DataOne> dataOne = new List<DataOne>();
            List<DataOne> datos = new List<DataOne>();
            try
            {
                dataOne = mapeador.mapper.Map<List<DataOne>>(model);
                datos = await _dataOneRepository.ConsultarDataOne();
                if (dataOne.Count > 0 )
                {

                    List<DataOne> insertar = (from d in dataOne
                                    where d.CampoIdentificador > 0
                                    select d).ToList();

                    List<DataOne> cruceSinFechaActualizar = (from d in datos join
                                        x in insertar on d.CampoIdentificador equals x.CampoIdentificador
                                 where string.IsNullOrEmpty(d.FechaActualizacion)
                                 select d).ToList();
                    if (cruceSinFechaActualizar.Count>0)
                    {
                        foreach (var item in cruceSinFechaActualizar)
                        {
                            item.FechaCarga = DateTime.Now.ToString();                            
                        }
                        await _dataOneRepository.ActualizarDataOne(cruceSinFechaActualizar);
                    }

                    List<DataOne> cruceConFechaActualizar = (from d in datos
                                                             join x in insertar on d.CampoIdentificador equals x.CampoIdentificador
                                                             where !string.IsNullOrEmpty(d.FechaActualizacion)
                                                             select new DataOne { Id = d.Id, Campodos = x.Campodos, CampoIdentificador = d.CampoIdentificador, Campook = d.Campook, Camporechazo = d.Camporechazo, Campouno = d.Campouno, FechaActualizacion = d.FechaActualizacion, FechaCarga = d.FechaCarga} ).ToList();

                    if (cruceConFechaActualizar.Count>0)
                    {
                        await _dataOneRepository.ActualizarDataOne(cruceConFechaActualizar);
                    }

                    int[] ids = datos.Select(x => x.CampoIdentificador).Distinct().ToArray();
                    if (ids.Count()>0)
                    {
                        List<DataOne> nuevos = insertar.Where(x => !ids.Contains(x.CampoIdentificador)).ToList();
                        await _dataOneRepository.CargarDataOne(nuevos);
                    }
                    else
                    {
                        await _dataOneRepository.CargarDataOne(insertar);
                    }                                                                         
                }
                return Response<bool>.Ok(true,"");
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error CargarDataOne");
                return Response<bool>.Error(ex);
            }            
        }

        public async  Task<Response<List<DataOneModel>>> ConsultarDataOne()
        {
            List<DataOneModel> resutado = new List<DataOneModel>();
            List<DataOne> datos = new List<DataOne>();
            try
            {
                datos = await _dataOneRepository.ConsultarDataOne();
                resutado = mapeador.mapper.Map<List<DataOneModel>>(datos);
                return Response<List<DataOneModel>>.Ok(resutado, "");
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error ConsultarDataOne");
                return Response<List<DataOneModel>>.Error(ex);
            }
            
        }
    }
}
