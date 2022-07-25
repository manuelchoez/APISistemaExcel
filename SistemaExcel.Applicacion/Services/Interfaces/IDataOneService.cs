using SistemaExcel.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Services.Interfaces
{
    public interface IDataOneService
    {
        Task<List<DataOneModel>> ConsultarDataOne();
        Task<bool> CargarDataOne(List<DataOneModel> model);
        Task<bool> ActualizarDataOne(List<DataOneModel> model);
    }
}
