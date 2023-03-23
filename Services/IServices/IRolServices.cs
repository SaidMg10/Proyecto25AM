using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IRolServices
    {
        public Task<Response<List<Rol>>> GetRol();
        public Task<Response<Rol>> CrearRol(RolsResponse Request);
        public Task<Response<Rol>> EditarRol([FromBody] RolsResponse res, int id);
        Task<Response<Rol>> EliminarRol (int id);
    }
}
