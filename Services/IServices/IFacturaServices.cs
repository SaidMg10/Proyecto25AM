using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto25AM.Services.IServices
{
    public interface IFacturaServices
    {
        public Task<Response<List<Factura>>> GetFactura();
        public Task<Response<Factura>> CrearFactura(FacturaResponse Request);
        public Task<Response<Factura>> EditarFactura([FromBody] FacturaResponse res, int id);
        Task<Response<Factura>> EliminarFactura(int id);
    }
}
