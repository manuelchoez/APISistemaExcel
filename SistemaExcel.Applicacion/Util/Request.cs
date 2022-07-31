using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Util
{
    public class Request<TRequest>
    {
        public int Transaccion { get; set; }
        public string IdSession { get; set; }
        public string Secuencial { get; set; }
        public TRequest Mensaje { get; set; }
    }

}
