using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class PuestoController : ControllerBase
        {
            private readonly IPuestoServices _puestoServices;
            public PuestoController(IPuestoServices puestoServices)
            {
                _puestoServices = puestoServices;

            }
            [HttpGet]
            public async Task<IActionResult> GetPuesto()
            {
                return Ok(await _puestoServices.GetPuesto());
            }
            [HttpDelete]
            public async Task<IActionResult> EliminarPuesto(int id)
            {
                return Ok(await _puestoServices.EliminarPuesto(id));
            }
            [HttpPut]
            public async Task<IActionResult> EditarPuesto([FromBody] PuestoResponse res, int id)
            {
                return Ok(await _puestoServices.EditarPuesto(res, id));
            }
            [HttpPost]
            public async Task<IActionResult> CrearPuesto([FromBody] PuestoResponse i)
            {
                return Ok(await _puestoServices.CrearPuesto(i));
            }
        }
}
