using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IClienteServices
    {
        public Task<Response<List<Cliente>>> GetClientes();
        public Task<Response<Cliente>> CrearCliente(ClienteResponse Request);
        public Task<Response<Cliente>> EditarCliente([FromBody] ClienteResponse res, int id);
        Task<Response<Cliente>> EliminarCliente(int id);
    }
}
