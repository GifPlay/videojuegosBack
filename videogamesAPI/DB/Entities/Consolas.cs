using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videogamesAPI.DB.Entities
{
    public class Consolas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idConsola { get; set; }
        public string empresa { get; set; }
        public string nombre { get; set; }
        public int lanzamiento { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public void MapToModel(Consolas g)
        {
            g.idConsola = idConsola;
            g.empresa = empresa;
            g.nombre = nombre;
            g.lanzamiento = lanzamiento;
        }

    }
}
