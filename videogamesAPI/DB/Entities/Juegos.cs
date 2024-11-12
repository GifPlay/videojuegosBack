using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videogamesAPI.DB.Entities
{
    public class Juegos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idJuego { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int anio { get; set;}
        public double calificacion { get; set; }
        public int jugadores { get; set; }
        public string ?franquicia { get; set;}
        public int idConsola { get; set; }
        public int idClasificacion { get; set; }
        public int idGenero { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public void MapToModel(Juegos j)
        {
            j.titulo = titulo;
            j.descripcion = descripcion;
            j.anio = anio; 
            j.calificacion = calificacion;
            j.jugadores = jugadores;
            j.franquicia = franquicia;
            j.idConsola = idConsola;
            j.idClasificacion = idClasificacion;
            j.idGenero = idGenero;
        }

    }
}
