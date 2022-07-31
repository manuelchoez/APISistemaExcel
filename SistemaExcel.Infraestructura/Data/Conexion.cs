using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using SistemaExcel.Applicacion.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Infraestructura.Data
{
    public class Conexion
    {        
        private Conexion()
        {
            
        }
       
        public static IMongoDatabase GetDatabase(IConfiguration _configuration)
        {
            MongoClient cliente = new MongoClient(_configuration.GetSection(ConstantesConexion.Server).Value);
            IMongoDatabase database = cliente.GetDatabase(_configuration.GetSection(ConstantesConexion.Database).Value);
            return database;
        }
    }
}
