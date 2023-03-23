using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class RolsController : ControllerBase
        {
            private readonly IRolServices _rolServices;
            public RolsController(IRolServices rolServices)
            {
                _rolServices = rolServices;

            }
            [HttpGet]
            public async Task<IActionResult> GetRol()
            {
                return Ok(await _rolServices.GetRol());
            }
            [HttpDelete]
            public async Task<IActionResult> EliminarRol(int id)
            {
                return Ok(await _rolServices.EliminarRol(id));
            }
            [HttpPut]
            public async Task<IActionResult> EditarRol([FromBody] RolsResponse res, int id)
            {
                return Ok(await _rolServices.EditarRol(res, id));
            }
            [HttpPost]
            public async Task<IActionResult> CrearRol([FromBody] RolsResponse i)
            {
                return Ok(await _rolServices.CrearRol(i));
            }
        }
    }
