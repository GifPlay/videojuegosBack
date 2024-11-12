using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using videogamesAPI.DB;
using videogamesAPI.DB.Entities;

namespace videogamesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JuegosController : Controller
    {
        private videogamesAPIContext _context;

        public JuegosController(videogamesAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public MethodResponse<List<Models.ViewJuegosConsolaModel>> Get()
        {
            var result = new MethodResponse<List<Models.ViewJuegosConsolaModel>> { Code = 100, Message = "ok", Result = null};

            try
            {
                result.Result = _context.ViewJuegosConsola.Select(s => new Models.ViewJuegosConsolaModel
                {
                    idJuego = s.idJuego,
                    titulo = s.titulo,
                   descripcion = s.descripcion,
                   anio = s.anio,
                   calificacion = s.calificacion,
                   jugadores = s.jugadores,
                   franquicia = s.franquicia,
                   idClasificacion = s.idClasificacion,
                   idConsola = s.idConsola,
                   idGenero = s.idGenero,
                   empresa = s.empresa,
                   nombre = s.nombre,
                   clasificacion = s.clasificacion,
                   edad = s.edad,
                   genero = s.genero,
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
       
        [HttpGet("getJuegoByCategoria")]
        public MethodResponse<List<Models.ViewJuegosConsolaModel>> GetByCategoria(int genero)
        {
            var result = new MethodResponse<List<Models.ViewJuegosConsolaModel>> { Code = 100, Message = "ok", Result = null };

            try
            {
                result.Result = _context.ViewJuegosConsola.Select(s => new Models.ViewJuegosConsolaModel
                {
                    idJuego = s.idJuego,
                    titulo = s.titulo,
                    descripcion = s.descripcion,
                    anio = s.anio,
                    calificacion = s.calificacion,
                    jugadores = s.jugadores,
                    franquicia = s.franquicia,
                    idClasificacion = s.idClasificacion,
                    idConsola = s.idConsola,
                    idGenero = s.idGenero,
                    empresa = s.empresa,
                    nombre = s.nombre,
                    clasificacion = s.clasificacion,
                    edad = s.edad,
                    genero = s.genero,
                    created_at = s.created_at,
                    updated_at = s.updated_at,
                }).Where(e => e.idGenero == genero).ToList();
            }
            catch (Exception ex)
            {
                result.Code = -100;
                result.Message = ex.Message;
                result.Result = null;
            }
            return result;
        }

        [HttpGet("getJuego")]
        public MethodResponse<Juegos> Get(int id)
        {
            var result = new MethodResponse<Juegos> { Code = 100, Message = "Success", Result = null };
            try
            {
                result.Result = _context.Juegos.FindAsync(id).Result;
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
        public MethodResponse<int> Post([FromBody] Juegos model)
        {
            var result = new MethodResponse<int> { Code = 100, Message = "Success", Result = 0 };
            try
            {
                var r = _context.Add(new Juegos
                {
                    titulo = model.titulo,
                    descripcion = model.descripcion,
                    anio = model.anio,
                    calificacion = model.calificacion,
                    jugadores = model.jugadores,
                    franquicia = model.franquicia,
                    idConsola = model.idConsola,
                    idClasificacion = model.idClasificacion,
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
        public MethodResponse<Juegos> Put([FromBody] Juegos model)
        {
            var result = new MethodResponse<Juegos> { Code = 100, Message = "Success", Result = null };
            try
            {
                _context.Attach(model);
                //Editables
                _context.Entry(model).Property(x => x.titulo).IsModified = true;              
                _context.Entry(model).Property(x => x.descripcion).IsModified = true;              
                _context.Entry(model).Property(x => x.anio).IsModified = true;              
                _context.Entry(model).Property(x => x.calificacion).IsModified = true;              
                _context.Entry(model).Property(x => x.jugadores).IsModified = true;              
                _context.Entry(model).Property(x => x.franquicia).IsModified = true;              
                _context.Entry(model).Property(x => x.idConsola).IsModified = true;     
                _context.Entry(model).Property(x => x.idClasificacion).IsModified = true;              
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
        public MethodResponse<Juegos> Delete(int id)
        {
            var result = new MethodResponse<Juegos> { Code = 100, Message = "Success", Result = null };
            try
            {
                var model = _context.Find<Juegos>(id);

                if (model == null)
                {
                    result.Message = "No se encontro el registro";
                    result.Code = -100;
                }
                _context.Remove(model);
                _context.SaveChanges();

                result.Message ="Se eliminó correctamente el registro de juego";
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
