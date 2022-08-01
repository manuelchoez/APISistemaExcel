using SistemaExcel.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Dominio.Repository
{
    public interface IDataTwoRepository
    {
        Task<List<DataTwo>> ConsultarDataTwo();
        Task<bool> CargarDataTwo(List<DataTwo> model);
    }
}
