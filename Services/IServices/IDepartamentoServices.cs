using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IDepartamentoServices
    {
        public Task<Response<List<Departamento>>> GetDepartamentos();
        public Task<Response<Departamento>> CrearDepartamento(DepartamentoResponse Request);
        public Task<Response<Departamento>> EditarDepartamento([FromBody] DepartamentoResponse res, int id);
        Task<Response<Departamento>> EliminarDepartamento(int id);
    }
}
