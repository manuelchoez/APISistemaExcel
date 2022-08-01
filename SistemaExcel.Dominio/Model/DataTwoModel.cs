using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Dominio.Model
{
    public class DataTwoModel
    {        
        public string? Id { get; set; }       
        public int CodigoBddConsulting { get; set; }      
        public string? Unificacion { get; set; }      
        public string? CodTotal { get; set; }      
        public string? NombreEquipo { get; set; }        
        public string? EspecificacionModelo { get; set; }       
        public string? FabricanteProduccion { get; set; }        
        public string? LugarAlmacenamiento { get; set; }
        public string? Mensaje { get; set; }
        public bool Estado { get; set; }
    }
}
