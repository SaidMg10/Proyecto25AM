using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;

        }
        //Creacion de funciones Crud
        public async Task<Response<List<Usuario>>> GetUsers()
        {
            try
            {
                Mensaje = "La lista de usuarios";
                var response = await _context.Usuarios.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Usuario>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay nada ";
                    return new Response<List<Usuario>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<Usuario>> EliminarUser(int id)
        {
            var usuario = _context.Usuarios.Find(id);
            try
            {
                if (usuario != null)
                {
                    _context.Usuarios.Remove(usuario);
                    await _context.SaveChangesAsync();

                    return new Response<Usuario>(usuario);
                }
                else
                {
                    return new Response<Usuario>(usuario);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);    
            }
            
        }
        public async Task<Response<Usuario>> EditarUser([FromBody] UsuarioResponse i, int id )
        {
            
            try                
            {
                var res = _context.Usuarios.Find(id);
                if (res != null)
                {
                    res.User=i.User;
                    res.Password=i.Password;
                    res.FechaRegistro=i.FechaRegistro;
                    res.FkRol=i.FkRol;
                    res.FkEmpleado=i.FkEmpleado;

                    _context.Usuarios.Update(res);
                    await _context.SaveChangesAsync();
                }
                
                    return new Response<Usuario>(res);
                
            }catch(Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse Request) 
        {
            try
            {
                Usuario user = new Usuario()
                {
                    User = Request.User,
                    Password = Request.Password,
                    FechaRegistro = Request.FechaRegistro,
                    FkEmpleado = Request.FkEmpleado,
                    FkRol = Request.FkRol
                };
                await _context.Usuarios.AddAsync(user);
                await _context.SaveChangesAsync();
                return new Response<Usuario>(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

    }
}
