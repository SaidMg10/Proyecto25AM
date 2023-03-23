using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;
namespace Proyecto25AM.Services.Services
{
    public class EmpleadosServices:IEmpleadosServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public  EmpleadosServices(ApplicationDbContext context)
        {
            _context = context;


        }
        //Creacion de funciones Crud
        public async Task<Response<List<Empleado>>> GetEmpleados()
        {
            try
            {
                Mensaje = "La lista de Empleados";
                var response = await _context.Empleados.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Empleado>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay nada ";
                    return new Response<List<Empleado>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<Empleado>> EliminarEmpleado(int id)
        {
            var empleado = _context.Empleados.Find(id);
            try
            {
                if (empleado != null)
                {
                    _context.Empleados.Remove(empleado);
                    await _context.SaveChangesAsync();

                    return new Response<Empleado>(empleado);
                }
                else
                {
                    return new Response<Empleado>(empleado);
                }
            }
            catch (Exception ex)   
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }

        }
        public async Task<Response<Empleado>> EditarEmpleado([FromBody] EmpleadoResponse i, int id)
        {

            try
            {
                var res = _context.Empleados.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;
                    res.Apellidos = i.Apellidos;
                    res.Direccion = i.Direccion;
                    res.Ciudad = i.Ciudad;
                    res.FkPuesto = i.FkPuesto;
                    res.FkDepartamento = i.FkDepartamento;

                    _context.Empleados.Update(res);
                    await _context.SaveChangesAsync();
                }

                return new Response<Empleado>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Empleado>> CrearEmpleado(EmpleadoResponse Request)
        {
            try
            {
                Empleado empleado = new Empleado()
                {
                    Nombre = Request.Nombre,
                    Apellidos = Request.Apellidos,
                    Direccion = Request.Direccion,
                    Ciudad = Request.Ciudad,
                    FkPuesto = Request.FkPuesto,
                    FkDepartamento = Request.FkDepartamento
                };
                await _context.Empleados.AddAsync(empleado);
                await _context.SaveChangesAsync();
                return new Response<Empleado>(empleado);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
    }
}
