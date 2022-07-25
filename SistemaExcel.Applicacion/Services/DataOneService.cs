using SistemaExcel.Applicacion.Services.Interfaces;
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
        public DataOneService(IDataOneRepository dataOneRepository)
        {
            _dataOneRepository = dataOneRepository;
        }

        public async Task<bool> ActualizarDataOne(List<DataOneModel> model)
        {
            bool resutado = true;
            try
            {
                resutado = await _dataOneRepository.ActualizarDataOne(model);
            }
            catch (Exception ex)
            {
                throw;
            }
            return resutado;
        }

        public async Task<bool> CargarDataOne(List<DataOneModel> model)
        {
            bool resutado = true;
            try
            {
                resutado = await _dataOneRepository.CargarDataOne(model);
            }
            catch (Exception ex)
            {
                throw;
            }
            return resutado;
        }

        public async  Task<List<DataOneModel>> ConsultarDataOne()
        {
            List<DataOneModel> resutado = new List<DataOneModel>();
            try
            {
                resutado = await _dataOneRepository.ConsultarDataOne();               
            }
            catch (Exception ex)
            {
                
            }
            return resutado;
        }
    }
}
