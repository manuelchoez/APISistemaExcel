using SistemaExcel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Dominio.Repository
{
    public interface IUsersRepository
    {
        Task<Users> Login(Users users);
    }
}
