using Serilog;
using SistemaExcel.Applicacion.Mapper.Interfaces;
using SistemaExcel.Applicacion.Services.Interfaces;
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

        public async Task<bool> ActualizarDataOne(List<DataOneModel> model)
        {
            bool resutado = true;
            List<DataOne> dataOne = new List<DataOne>();
            try
            {
                dataOne = mapeador.mapper.Map<List<DataOne>>(model);
                resutado = await _dataOneRepository.ActualizarDataOne(dataOne);
            }
            catch (Exception ex)
            {               
                _log.Error(ex, "Error ActualizarDataOne");                
            }
            return resutado;
        }

        public async Task<bool> CargarDataOne(List<DataOneModel> model)
        {
            bool resutado = true;
            List<DataOne> dataOne = new List<DataOne>();
            List<DataOne> datos = new List<DataOne>();
            try
            {
                dataOne = mapeador.mapper.Map<List<DataOne>>(model);
                datos = await _dataOneRepository.ConsultarDataOne();
                if (dataOne.Count > 0 )
                {
                    var cruce = (from d in datos join
                                        x in dataOne on d.CampoIdentificador equals x.CampoIdentificador
                                 where string.IsNullOrEmpty(d.FechaActualizacion)
                                 select d).ToList();
                    if (cruce.Count>0)
                    {
                        foreach (var item in cruce)
                        {
                            item.FechaCarga = DateTime.Now.ToString();
                            dataOne.Remove(item);
                        }
                        await _dataOneRepository.ActualizarDataOne(cruce);
                    }

                    await _dataOneRepository.CargarDataOne(dataOne);                                                      
                }                                    
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error CargarDataOne");
            }
            return resutado;
        }

        public async  Task<List<DataOneModel>> ConsultarDataOne()
        {
            List<DataOneModel> resutado = new List<DataOneModel>();
            List<DataOne> datos = new List<DataOne>();
            try
            {
                datos = await _dataOneRepository.ConsultarDataOne();
                resutado = mapeador.mapper.Map<List<DataOneModel>>(datos);
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error ConsultarDataOne");
            }
            return resutado;
        }
    }
}
