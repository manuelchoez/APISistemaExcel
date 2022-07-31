
using SistemaExcel.Dominio.Entidades;
using SistemaExcel.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Dominio.Repository
{
    public interface IDataOneRepository
    {
        Task<List<DataOne>> ConsultarDataOne();
        Task<bool> CargarDataOne(List<DataOne> model);
        Task<bool> ActualizarDataOne(List<DataOne> model);
    }
}
