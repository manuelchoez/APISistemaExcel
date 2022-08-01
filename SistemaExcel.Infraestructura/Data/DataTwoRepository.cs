using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SistemaExcel.Applicacion.Constantes;
using SistemaExcel.Dominio.Entidades;
using SistemaExcel.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Infraestructura.Data
{
    public class DataTwoRepository : IDataTwoRepository
    {
        private readonly IConfiguration _configuration;

        public IMongoCollection<DataTwo> Collection()
        {

            IMongoDatabase database = Conexion.GetDatabase(_configuration);
            IMongoCollection<DataTwo> collections = database.GetCollection<DataTwo>(_configuration.GetSection(ConstantesConexion.CollectionDt).Value);
            return collections;
        }

        public DataTwoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CargarDataTwo(List<DataTwo> model)
        {
            bool resultado = true;
            if (model.Count() > 0)
            {
                foreach (var item in model)
                {
                    await Collection().InsertOneAsync(item);
                }
            }
            return resultado;
        }

        public async Task<List<DataTwo>> ConsultarDataTwo()
        {
            List<DataTwo> listaRetorno = new List<DataTwo>();
            listaRetorno = await Collection().FindAsync(x => true).Result.ToListAsync();
            return listaRetorno;
        }
    }
}
