using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IPuestoServices
    {
        public Task<Response<List<Puesto>>> GetPuesto();
        public Task<Response<Puesto>> CrearPuesto(PuestoResponse Request);
        public Task<Response<Puesto>> EditarPuesto([FromBody] PuestoResponse res, int id);
        Task<Response<Puesto>> EliminarPuesto(int id);
    }
}
