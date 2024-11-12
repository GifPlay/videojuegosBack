using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videogamesAPI.DB.Entities
{
    public class Clasificacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idClasificacion { get; set; }
        public string  clasificacion { get; set; }
        public int edad { get; set; }
        public string descripcion { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public void MapToModel(Clasificacion c)
        {
            c.idClasificacion = idClasificacion;
            c.clasificacion = clasificacion;
            c.edad = edad;
            c.descripcion = descripcion;
        }

    }
}
