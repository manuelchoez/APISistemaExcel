using SistemaExcel.Applicacion.Util;
using SistemaExcel.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Services.Interfaces
{
    public interface IDataTwoService
    {
        Task<Response<List<DataTwoModel>>> ConsultarDataTwo();
        Task<Response<bool>> CargarDataTwo(List<DataTwoModel> model);
    }
}
