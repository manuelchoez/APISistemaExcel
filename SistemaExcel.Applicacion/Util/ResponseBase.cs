using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Util
{
    public abstract class ResponseBase
    {
        /// <summary>
        /// Codigo de respuesta transaccion
        /// </summary>
        public string? Codigo { get; set; }
        /// <summary>
        /// Bandera para identificar si es error o no tras realizar una solicitud
        /// </summary>
        public bool EsError { get; set; }
        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public object? Mensaje { get; set; }
    }
}
