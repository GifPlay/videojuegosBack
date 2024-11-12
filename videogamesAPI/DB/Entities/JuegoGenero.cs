using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace videogamesAPI.DB.Entities
{
    public class JuegoGenero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idJuegoGenero { get; set; }
        public int idJuego { get; set; }
        public int idGenero { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

        public void MapToModel(JuegoGenero jg)
        {
           jg.idJuegoGenero = idJuegoGenero;
           jg.idGenero = idGenero;
           jg.idJuego = idJuego;
        }

    }
}
