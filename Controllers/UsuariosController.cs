using Domain.Dto;
using Microsoft.AspNetCore.Mvc;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioServices _usuarioServices;
        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices= usuarioServices;

        }
        [HttpGet]   
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _usuarioServices.GetUsers());
        }
        [HttpDelete]
        public async Task<IActionResult> EliminarUsers(int id)
        {
            return Ok(await _usuarioServices.EliminarUser(id));
        }
        [HttpPut]
        public async Task<IActionResult> EditarUser([FromBody] UsuarioResponse res, int id)
        {
            return Ok(await _usuarioServices.EditarUser(res,id));
        }
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]UsuarioResponse i) 
        {
            return Ok(await _usuarioServices.CrearUsuario(i));
        }
    }
}
