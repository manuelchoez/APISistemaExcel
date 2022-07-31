using Microsoft.Extensions.Configuration;
using Serilog;
using SistemaExcel.Applicacion.Constantes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Infraestructura.Log
{    
    public class SerilogHelper
    {
        private readonly IConfiguration _configuration;

        public SerilogHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public LoggerConfiguration SerilogConfigure()
        {            
            return new LoggerConfiguration()                                
                .WriteTo.MongoDB(
                   databaseUrl: _configuration.GetSection(ConstantesConexion.Server).Value,
                   collectionName: _configuration.GetSection(ConstantesConexion.CollectionLog).Value,
                   restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning                           
                );
        }
    }
}
