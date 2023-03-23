using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : Controller
    {
        private readonly IFacturaServices _facturaServices;
        public FacturaController(IFacturaServices facturaServices)
        {
            _facturaServices = facturaServices;

        }
        [HttpGet]
        public async Task<IActionResult> GetFactura()
        {
            return Ok(await _facturaServices.GetFactura());
        }
        [HttpDelete]
        public async Task<IActionResult> EliminarFactura(int id)
        {
            return Ok(await _facturaServices.EliminarFactura(id));
        }
        [HttpPut]
        public async Task<IActionResult> EditarFactura([FromBody] FacturaResponse res, int id)
        {
            return Ok(await _facturaServices.EditarFactura(res, id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearFactura([FromBody] FacturaResponse i)
        {
            return Ok(await _facturaServices.CrearFactura(i));
        }
    }
}
