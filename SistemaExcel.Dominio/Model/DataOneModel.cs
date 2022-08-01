using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Dominio.Model
{
    public class DataOneModel
    {
        public string? Id { get; set; }
        public int CampoIdentificador { get; set; }
        public int Campouno { get; set; }
        public string? Campodos { get; set; }
        public bool Campook { get; set; }
        public bool Camporechazo { get; set; }
        public string? FechaActualizacion { get; set; }
        public string? FechaCarga { get; set; }
        public string? Mensaje { get; set; }
        public bool Estado { get; set; }
    }
}
