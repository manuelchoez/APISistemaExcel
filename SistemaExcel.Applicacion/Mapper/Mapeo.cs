using AutoMapper;
using SistemaExcel.Applicacion.Mapper.Interfaces;
using SistemaExcel.Dominio.Entidades;
using SistemaExcel.Dominio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaExcel.Applicacion.Mapper
{
    public class Mapeo:IMapear
    {
        public Mapeo()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DataOne, DataOneModel>().ReverseMap();

            });
            mapper = config.CreateMapper();
        }
    }
}
