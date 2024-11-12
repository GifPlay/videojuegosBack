namespace videogamesAPI.Models
{
    public class ViewJuegosConsolaModel
    {
        public int idJuego { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int anio { get; set; }
        public double calificacion { get; set; }
        public int jugadores { get; set; }
        public string? franquicia { get; set; }
        public int idConsola { get; set; }
        public int idClasificacion { get; set; }
        public int idGenero { get; set; }
        public string nombre { get; set; }
        public string empresa { get; set; }
        public string clasificacion { get; set; }
        public int edad { get; set; }
        public string genero { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
