﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using videogamesAPI.DB;
using videogamesAPI.DB.Entities;

namespace videogamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : Controller
    {
        private videogamesAPIContext _context;

        public GeneroController(videogamesAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public MethodResponse<List<Models.GeneroModel>> Get()
        {
            var result = new MethodResponse<List<Models.GeneroModel>> { Code = 100, Message = "ok", Result = null};

            try
            {
                result.Result = _context.Generos.Select(s => new Models.GeneroModel
                {
                    idGenero = s.idGenero,
                    nombre = s.nombre,
                    descripcion = s.descripcion,
                    created_at = s.created_at,
                    updated_at = s.updated_at,
                }).ToList();
            }
            catch(Exception ex)
            {
                result.Code = -100;
                result.Message = ex.Message;
                result.Result = null;
            }

            return result;
        }

        [HttpGet("getGenero")]
        public MethodResponse<Generos> Get(int id)
        {
            var result = new MethodResponse<Generos> { Code = 100, Message = "Success", Result = null };
            try
            {
                result.Result = _context.Generos.FindAsync(id).Result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                result.Code = -100;
                result.Result = null;
            }
            return result;
        }

        [HttpPost]
        public MethodResponse<int> Post([FromBody] Generos model)
        {
            var result = new MethodResponse<int> { Code = 100, Message = "Success", Result = 0 };
            try
            {
                var r = _context.Add(new Generos
                {
                    nombre = model.nombre,
                    descripcion = model.descripcion,
                    created_at = null,
                    updated_at = null
                });
                _context.SaveChanges();
                result.Result = 0;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Code = -100;
                result.Result = 0;
            }
            return result;

        }

        [HttpPut]
        public MethodResponse<Generos> Put([FromBody] Generos model)
        {
            var result = new MethodResponse<Generos> { Code = 100, Message = "Success", Result = null };
            try
            {
                _context.Attach(model);
                //Editables
                _context.Entry(model).Property(x => x.nombre).IsModified = true;              
                _context.Entry(model).Property(x => x.descripcion).IsModified = true;              
                //No editables
                _context.Entry(model).Property(x => x.created_at).IsModified = false;
                _context.Entry(model).Property(x => x.updated_at).IsModified = false;
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                result.Message = e.Message;
                result.Code = -100;
                result.Result = null;
            }
            return result;
        }

        [HttpDelete]
        public MethodResponse<Generos> Delete(int id)
        {
            var result = new MethodResponse<Generos> { Code = 100, Message = "Success", Result = null };
            try
            {
                var genero = _context.Find<Generos>(id);

                if (genero == null)
                {
                    result.Message = "No se encontro el registro";
                    result.Code = -100;
                }
                _context.Remove(genero);
                _context.SaveChanges();

                result.Message ="Se eliminó correctamente el registro de genero";
                result.Code = 100;
               
            }
            catch (Exception e)
            {
                result.Message = "Se produjo un error: " + e;
                result.Code = -100;
            }
            return result;
        }


    }
}