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
    public class DataTwoService : IDataTwoService
    {
        private readonly IDataTwoRepository _datatwoRepository;
        protected IMapear mapeador;
        private readonly ILogger _log;
        public DataTwoService(IDataTwoRepository datatwoRepository, IMapear mapeador, ILogger log)
        {
            _datatwoRepository = datatwoRepository;
            this.mapeador = mapeador;
            _log = log.ForContext<DataTwoService>();
        }

        public async Task<Response<bool>> CargarDataTwo(List<DataTwoModel> model)
        {
            List<DataTwo> datatwo = new List<DataTwo>();
            
            try
            {
                datatwo = mapeador.mapper.Map<List<DataTwo>>(model);
                await _datatwoRepository.CargarDataTwo(datatwo);
                
                return Response<bool>.Ok(true, "");
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error CargarDataOne");
                return Response<bool>.Error(ex);
            }
        }

        public async Task<Response<List<DataTwoModel>>> ConsultarDataTwo()
        {
            List<DataTwoModel> resutado = new List<DataTwoModel>();
            List<DataTwo> datos = new List<DataTwo>();
            try
            {
                datos = await _datatwoRepository.ConsultarDataTwo();
                resutado = mapeador.mapper.Map<List<DataTwoModel>>(datos);
                return Response<List<DataTwoModel>>.Ok(resutado, "");
            }
            catch (Exception ex)
            {
                _log.Error(ex, "Error ConsultarDataTwo");
                return Response<List<DataTwoModel>>.Error(ex);
            }
        }
    }
}
