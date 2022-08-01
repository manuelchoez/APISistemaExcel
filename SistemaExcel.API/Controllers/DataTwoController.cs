using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaExcel.Applicacion.Services.Interfaces;
using SistemaExcel.Applicacion.Util;
using SistemaExcel.Dominio.Model;

namespace SistemaExcel.API.Controllers
{
    [Authorize]
    [Route("api/datatwo")]
    [ApiController]
    public class DataTwoController : ControllerBase
    {
        private readonly IDataTwoService _datatwoService;
        public DataTwoController(IDataTwoService datatwoService)
        {
            _datatwoService = datatwoService;
        }

        [HttpGet]
        [Route("ConsultarDataTwo")]
        public Task<Response<List<DataTwoModel>>> ConsultarDataTwo()
        {
            return _datatwoService.ConsultarDataTwo();
        }

        [HttpPost]
        [Route("CargarDataTwo")]
        public Task<Response<bool>> CargarDataTwo(List<DataTwoModel> model)
        {
            return _datatwoService.CargarDataTwo(model);
        }

    }
}
