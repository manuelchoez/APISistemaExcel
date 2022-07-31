using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Dominio.Repository
{
    public interface IToken
    {
         string GenerarTokenJwt(string username);
    }
}
