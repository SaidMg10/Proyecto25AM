using Domain.Dto;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto25AM.Context;
using Proyecto25AM.Services.IServices;

namespace Proyecto25AM.Services.Services
{
    public class DepartamentoServices:IDepartamentoServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;
        public DepartamentoServices(ApplicationDbContext context)
        {
            _context = context;


        }
        //Creacion de funciones Crud
        public async Task<Response<List<Departamento>>> GetDepartamentos()
        {
            try
            {
                Mensaje = "La lista de Departamentos";
                var response = await _context.Departamentos.ToListAsync();
                if (response.Count > 0)
                {
                    return new Response<List<Departamento>>(response, Mensaje);

                }
                else
                {
                    Mensaje = "No hay Departamentos";
                    return new Response<List<Departamento>>(Mensaje);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task<Response<Departamento>> EliminarDepartamento(int id)
        {
            var departamento= _context.Departamentos.Find(id);
            try
            {
                if (departamento != null)
                {
                    _context.Departamentos.Remove(departamento);
                    await _context.SaveChangesAsync();

                    return new Response<Departamento>(departamento);
                }
                else
                {
                    return new Response<Departamento>(departamento);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }

        }
        public async Task<Response<Departamento>> EditarDepartamento([FromBody] DepartamentoResponse i, int id)
        {

            try
            {
                var res = _context.Departamentos.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;

                    _context.Departamentos.Update(res);
                    await _context.SaveChangesAsync();
                }

                return new Response<Departamento>(res);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }
        public async Task<Response<Departamento>> CrearDepartamento(DepartamentoResponse Request)
        {
            try
            {
                Departamento departamento = new Departamento()
                {
                    Nombre = Request.Nombre
                };
                await _context.Departamentos.AddAsync(departamento);
                await _context.SaveChangesAsync();
                return new Response<Departamento>(departamento);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error" + ex.Message);
            }
        }

    }
}
