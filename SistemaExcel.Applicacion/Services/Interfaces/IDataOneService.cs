using SistemaExcel.Applicacion.Util;
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
        Task<Response<List<DataOneModel>>> ConsultarDataOne();
        Task<Response<bool>> CargarDataOne(List<DataOneModel> model);
        Task<Response<bool>> ActualizarDataOne(List<DataOneModel> model);
    }
}
