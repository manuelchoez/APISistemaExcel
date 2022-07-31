using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Dominio.Model
{
    public class UsersModel
    {
       
        public string? Id { get; set; }
        
        public string? UerName { get; set; }
       
        public string? Password { get; set; }
        
        public string? Perfil { get; set; }
        public string? Mensaje { get; set; }
        public bool Estado { get; set; }
        public string? Token { get; set; }
    }
}
