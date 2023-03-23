using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> GetUsers();
        public Task<Response<Usuario>> CrearUsuario(UsuarioResponse Request);
        public Task<Response<Usuario>> EditarUser([FromBody] UsuarioResponse res, int id);
        Task<Response<Usuario>> EliminarUser(int id);
    }
}
