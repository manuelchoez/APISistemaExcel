using SistemaExcel.Applicacion.Util;
using SistemaExcel.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Response
{
    public class DataOneResponse : ResponseBase
    {
        Task<bool> ActualizarDataOne { get; set; }
        Task<bool> CargarDataOne { get; set; }
        Task<List<DataOneModel>> ConsultarDataOne { get; set; }

    }
}
