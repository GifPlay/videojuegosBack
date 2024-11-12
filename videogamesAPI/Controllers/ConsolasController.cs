using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using videogamesAPI.DB;
using videogamesAPI.DB.Entities;

namespace videogamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsolasController : Controller
    {
        private videogamesAPIContext _context;

        public ConsolasController(videogamesAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public MethodResponse<List<Models.ConsolaModel>> Get()
        {
            var result = new MethodResponse<List<Models.ConsolaModel>> { Code = 100, Message = "ok", Result = null};

            try
            {
                result.Result = _context.Consolas.Select(s => new Models.ConsolaModel
                {
                    idConsola = s.idConsola,
                    nombre = s.nombre,
                    empresa = s.empresa,
                    lanzamiento = s.lanzamiento,
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

        [HttpGet("getConsola")]
        public MethodResponse<Consolas> Get(int id)
        {
            var result = new MethodResponse<Consolas> { Code = 100, Message = "Success", Result = null };
            try
            {
                result.Result = _context.Consolas.FindAsync(id).Result;
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
        public MethodResponse<int> Post([FromBody] Consolas model)
        {
            var result = new MethodResponse<int> { Code = 100, Message = "Success", Result = 0 };
            try
            {
                var r = _context.Add(new Consolas
                {
                    nombre = model.nombre,
                    empresa = model.empresa,
                    lanzamiento = model.lanzamiento,
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
        public MethodResponse<Consolas> Put([FromBody] Consolas model)
        {
            var result = new MethodResponse<Consolas> { Code = 100, Message = "Success", Result = null };
            try
            {
                _context.Attach(model);
                //Editables
                _context.Entry(model).Property(x => x.nombre).IsModified = true;              
                _context.Entry(model).Property(x => x.lanzamiento).IsModified = true;              
                _context.Entry(model).Property(x => x.empresa).IsModified = true;              
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
        public MethodResponse<Consolas> Delete(int id)
        {
            var result = new MethodResponse<Consolas> { Code = 100, Message = "Success", Result = null };
            try
            {
                var consola = _context.Find<Consolas>(id);

                if (consola == null)
                {
                    result.Message = "No se encontro el registro";
                    result.Code = -100;
                }
                _context.Remove(consola);
                _context.SaveChanges();

                result.Message ="Se eliminó correctamente el registro de consola";
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
