using SistemaExcel.Applicacion.Util;
using SistemaExcel.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Response
{
    public class UsersResponse : ResponseBase
    {

        public Task<UsersModel> Login { get; set; }
    }
}
