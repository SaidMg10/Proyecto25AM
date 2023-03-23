using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class PuestoServices : IPuestoServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public PuestoServices(ApplicationDbContext context)
        {
            _context = context;

        }
        //Creacion de funciones Crud
        public async Task<Response<List<Puesto>>> GetPuesto()
        {
            try
            {
                Mensaje = "La lista de Puestos";
                var response = await _context.Puestos.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Puesto>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay registro";
                    return new Response<List<Puesto>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<Puesto>> EliminarPuesto(int id)
        {
            var puesto = _context.Puestos.Find(id);
            try
            {
                if (puesto != null)
                {
                    _context.Puestos.Remove(puesto);
                    await _context.SaveChangesAsync();

                    return new Response<Puesto>(puesto);
                }
                else
                {
                    return new Response<Puesto>(puesto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }

        }
        public async Task<Response<Puesto>> EditarPuesto([FromBody] PuestoResponse i, int id)
        {

            try
            {
                var res = _context.Puestos.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;


                    _context.Puestos.Update(res);
                    await _context.SaveChangesAsync();
                }

                return new Response<Puesto>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Puesto>> CrearPuesto(PuestoResponse Request)
        {
            try
            {
                Puesto puesto= new Puesto()
                {
                    Nombre = Request.Nombre
                };
                await _context.Puestos.AddAsync(puesto);
                await _context.SaveChangesAsync();
                return new Response<Puesto>(puesto);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
