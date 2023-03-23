using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class ClienteServices:IClienteServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public ClienteServices(ApplicationDbContext context)
        {
            _context = context;
        }
        //Creacion de funciones Crud
        public async Task<Response<List<Cliente>>> GetClientes()
        {
            try
            {
                Mensaje = "La lista de Clientes";
                var response = await _context.Clientes.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Cliente>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay clientes";
                    return new Response<List<Cliente>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<Cliente>> EliminarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);
            try
            {
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                    await _context.SaveChangesAsync();

                    return new Response<Cliente>(cliente);
                }
                else
                {
                    return new Response<Cliente>(cliente);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }

        }
        public async Task<Response<Cliente>> EditarCliente([FromBody] ClienteResponse i, int id)
        {

            try
            {
                var res = _context.Clientes.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;
                    res.Apellido = i.Apellido;
                    res.Telefono= i.Telefono;
                    res.Direccion = i.Direccion;
                    res.Email = i.Email;

                    _context.Clientes.Update(res);
                    await _context.SaveChangesAsync();
                }

                return new Response<Cliente>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Cliente>> CrearCliente(ClienteResponse Request)
        {
            try
            {
                Cliente cliente = new Cliente()
                {
                    Nombre = Request.Nombre,
                    Apellido = Request.Apellido,
                    Telefono = Request.Telefono,
                    Direccion = Request.Direccion,
                    Email = Request.Email
                };
                await _context.Clientes.AddAsync(cliente);
                await _context.SaveChangesAsync();
                return new Response<Cliente>(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
