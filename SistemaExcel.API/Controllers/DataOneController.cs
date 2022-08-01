﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaExcel.Applicacion.Services.Interfaces;
using SistemaExcel.Applicacion.Util;
using SistemaExcel.Dominio.Model;

namespace SistemaExcel.API.Controllers
{
    [Authorize]
    [Route("api/dataone")]
    [ApiController]
    public class DataOneController : ControllerBase
    {

        private readonly IDataOneService _dataOneService;       
        public DataOneController(IDataOneService dataOneService)
        {
            _dataOneService = dataOneService;
        }

        [HttpGet]
        [Route("ConsultarDataOne")]
        public Task<Response<List<DataOneModel>>> ConsultarDataOne()
        {
            return _dataOneService.ConsultarDataOne();
        }

        [HttpPost]
        [Route("CargarDataOne")]
        public Task<Response<bool>> CargarDataOne(List<DataOneModel> model)
        {
            return _dataOneService.CargarDataOne(model);
        }

        [HttpPut]
        [Route("ActualizarDataOne")]
        public Task<Response<bool>> ActualizarDataOne(List<DataOneModel> model)
        {
            return _dataOneService.ActualizarDataOne(model);
        }

        [HttpGet]
        [Route("Prueba")]
        public string Prueba()
        {
            return  "Hola mundo";
        }
    }
}
