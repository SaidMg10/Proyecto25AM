using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteServices _clienteServices;
        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;

        }
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            return Ok(await _clienteServices.GetClientes());
        }
        [HttpDelete]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            return Ok(await _clienteServices.EliminarCliente(id));
        }
        [HttpPut]
        public async Task<IActionResult> EditarCliente([FromBody] ClienteResponse res, int id)
        {
            return Ok(await _clienteServices.EditarCliente(res, id));
        }
        [HttpPost]
        public async Task<IActionResult> CrearCliente([FromBody] ClienteResponse i)
        {
            return Ok(await _clienteServices.CrearCliente(i));
        }
    }
}
