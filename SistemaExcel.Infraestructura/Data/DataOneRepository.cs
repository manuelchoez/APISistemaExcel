using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SistemaExcel.Applicacion.Constantes;
using SistemaExcel.Dominio.Entidades;
using SistemaExcel.Dominio.Model;
using SistemaExcel.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Infraestructura.Data
{
    public class DataOneRepository: IDataOneRepository
    {        
        private readonly IConfiguration _configuration;

        public IMongoCollection<DataOne> Collection()
        {

            IMongoDatabase database = Conexion.GetDatabase(_configuration);                       
            IMongoCollection<DataOne> collections = database.GetCollection<DataOne>(_configuration.GetSection(ConstantesConexion.Collection).Value);
            return collections;
        }

        public DataOneRepository(IConfiguration configuration)
        {            
            _configuration = configuration;
        }

        public async Task<bool> ActualizarDataOne(List<DataOne> model)
        {
            bool resultado = true;
            DataOne dataModel = new DataOne();                       
            if (model.Count()>0)
            {
                foreach (var item in model)
                {
                    dataModel = item;
                   await Collection().ReplaceOneAsync(data => data.Id == item.Id, dataModel);                                 
                }
            }
            return resultado;
        }

        public async Task<bool> CargarDataOne(List<DataOne> model)
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
               

        public async Task<List<DataOne>> ConsultarDataOne()
        {
            List<DataOne> listaRetorno = new List<DataOne>() ;            
            listaRetorno = await Collection().FindAsync(x => true).Result.ToListAsync();            
            return listaRetorno;
        }        

        
    }
}
