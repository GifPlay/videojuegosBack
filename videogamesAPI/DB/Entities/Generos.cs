using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videogamesAPI.DB.Entities
{
    public class Generos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ?idGenero { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public void MapToModel(Generos g)
        {
            g.idGenero = idGenero;
            g.nombre = nombre;
            g.descripcion = descripcion;
        }

    }
}
