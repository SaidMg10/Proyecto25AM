using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IEmpleadosServices
    {
        public Task<Response<List<Empleado>>> GetEmpleados();
        public Task<Response<Empleado>> CrearEmpleado(EmpleadoResponse Request);
        public Task<Response<Empleado>> EditarEmpleado([FromBody] EmpleadoResponse res, int id);
        Task<Response<Empleado>> EliminarEmpleado(int id);
    }
}
