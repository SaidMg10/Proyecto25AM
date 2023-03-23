using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : Controller
    {
        private readonly IDepartamentoServices _departamentoServices;
        public DepartamentoController(IDepartamentoServices departamentoServices)
        {
            _departamentoServices = departamentoServices;

        }
        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            return Ok(await _departamentoServices.GetDepartamentos());
        }
        [HttpDelete]
        public async Task<IActionResult> EliminarDepartamento(int id)
        {
            return Ok(await _departamentoServices.EliminarDepartamento(id));
        }
        [HttpPut]
        public async Task<IActionResult> EditarDepartamento([FromBody] DepartamentoResponse res, int id)
        {
            return Ok(await _departamentoServices.EditarDepartamento(res, id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearDepartamento([FromBody] DepartamentoResponse i)
        {
            return Ok(await _departamentoServices.CrearDepartamento(i));
        }
    }
}
