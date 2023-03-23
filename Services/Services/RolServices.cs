using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class RolServices : IRolServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public RolServices(ApplicationDbContext context)
        {
            _context = context;


        }
        //Creacion de funciones Crud
        public async Task<Response<List<Rol>>> GetRol()
        {
            try
            {
                Mensaje = "La lista de Roles";
                var response = await _context.Rols.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Rol>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay registro";
                    return new Response<List<Rol>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<Rol>> EliminarRol(int id)
        {
            var Rol = _context.Rols.Find(id);
            try
            {
                if (Rol != null)
                {
                    _context.Rols.Remove(Rol);
                    await _context.SaveChangesAsync();

                    return new Response<Rol>(Rol);
                }
                else
                {
                    return new Response<Rol>(Rol);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }

        }
        public async Task<Response<Rol>> EditarRol([FromBody] RolsResponse i, int id)
        {

            try
            {
                var res = _context.Rols.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;
                    

                    _context.Rols.Update(res);
                    await _context.SaveChangesAsync();
                }

                return new Response<Rol>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Rol>> CrearRol(RolsResponse Request)
        {
            try
            {
                Rol rols = new Rol()
                {
                    Nombre = Request.Nombre
                };
                await _context.Rols.AddAsync(rols);
                await _context.SaveChangesAsync();
                return new Response<Rol>(rols);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
