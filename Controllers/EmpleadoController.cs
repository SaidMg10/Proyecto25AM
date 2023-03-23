using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly IEmpleadosServices _empleadoServices;
        public EmpleadoController(IEmpleadosServices empleadoServices)
        {
            _empleadoServices = empleadoServices;

        }
        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            return Ok(await _empleadoServices.GetEmpleados());
        }
        [HttpDelete]
        public async Task<IActionResult> EliminarEmpleado(int id)
        {
            return Ok(await _empleadoServices.EliminarEmpleado(id));
        }
        [HttpPut]
        public async Task<IActionResult> EditarEmpleado([FromBody] EmpleadoResponse res, int id)
        {
            return Ok(await _empleadoServices.EditarEmpleado(res, id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearEmpleado([FromBody] EmpleadoResponse i)
        {
            return Ok(await _empleadoServices.CrearEmpleado(i));
        }
    }
}
