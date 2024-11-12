using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using videogamesAPI.DB;
using videogamesAPI.DB.Entities;

namespace videogamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegosGenero : Controller
    {
        private videogamesAPIContext _context;

        public JuegosGenero(videogamesAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public MethodResponse<List<Models.JuegosGeneroModel>> Get()
        {
            var result = new MethodResponse<List<Models.JuegosGeneroModel>> { Code = 100, Message = "ok", Result = null};

            try
            {
                result.Result = _context.JuegoGenero.Select(s => new Models.JuegosGeneroModel
                {
                   idJuegoGenero = s.idJuegoGenero,
                   idJuego = s.idJuego,
                   idGenero = s.idGenero,
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

        [HttpGet("getJuegoGenero")]
        public MethodResponse<JuegoGenero> Get(int id)
        {
            var result = new MethodResponse<JuegoGenero> { Code = 100, Message = "Success", Result = null };
            try
            {
                result.Result = _context.JuegoGenero.FindAsync(id).Result;
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
        public MethodResponse<int> Post([FromBody] JuegoGenero model)
        {
            var result = new MethodResponse<int> { Code = 100, Message = "Success", Result = 0 };
            try
            {
                var r = _context.Add(new JuegoGenero
                {
                    idJuego = model.idJuego,
                    idGenero = model.idGenero,
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
        public MethodResponse<JuegoGenero> Put([FromBody] JuegoGenero model)
        {
            var result = new MethodResponse<JuegoGenero> { Code = 100, Message = "Success", Result = null };
            try
            {
                _context.Attach(model);
                //Editables
                _context.Entry(model).Property(x => x.idJuego).IsModified = true;              
                _context.Entry(model).Property(x => x.idGenero).IsModified = true;                  
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
        public MethodResponse<JuegosGenero> Delete(int id)
        {
            var result = new MethodResponse<JuegosGenero> { Code = 100, Message = "Success", Result = null };
            try
            {
                var model = _context.Find<JuegosGenero>(id);

                if (model == null)
                {
                    result.Message = "No se encontro el registro";
                    result.Code = -100;
                }
                _context.Remove(model);
                _context.SaveChanges();

                result.Message ="Se eliminó correctamente el registro de clasificación";
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
