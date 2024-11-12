namespace videogamesAPI.Models
{
    public class JuegosGeneroModel
    {
        public int idJuegoGenero { get; set; }
        public int idJuego { get; set; }
        public int idGenero { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
