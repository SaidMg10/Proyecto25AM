using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class FacturaServices:IFacturaServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public FacturaServices(ApplicationDbContext context)
        {
            _context = context;


        }
        //Creacion de funciones Crud
        public async Task<Response<List<Factura>>> GetFactura()
        {
            try
            {
                Mensaje = "La lista de Facturas";
                var response = await _context.Facturas.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Factura>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay registro";
                    return new Response<List<Factura>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<Factura>> EliminarFactura(int id)
        {
            var factura = _context.Facturas.Find(id);
            try
            {
                if (factura != null)
                {
                    _context.Facturas.Remove(factura);
                    await _context.SaveChangesAsync();

                    return new Response<Factura>(factura);
                }
                else
                {
                    return new Response<Factura>(factura);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }

        }
        public async Task<Response<Factura>> EditarFactura([FromBody] FacturaResponse i, int id)
        {

            try
            {
                var res = _context.Facturas.Find(id);
                if (res != null)
                {
                    res.RazonSocial = i.RazonSocial;
                    res.Fecha = i.Fecha;
                    res.RFC = i.RFC;
                    res.FkCliente = i.FkCliente;

                    _context.Facturas.Update(res);
                    await _context.SaveChangesAsync();
                }

                return new Response<Factura>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Factura>> CrearFactura(FacturaResponse Request)
        {
            try
            {
                Factura factura = new Factura()
                {
                    RazonSocial = Request.RazonSocial,
                    Fecha = Request.Fecha,
                    RFC = Request.RFC,
                    FkCliente = Request.FkCliente
            };
                await _context.Facturas.AddAsync(factura);
                await _context.SaveChangesAsync();
                return new Response<Factura>(factura);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
