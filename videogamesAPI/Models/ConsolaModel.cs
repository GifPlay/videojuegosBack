namespace videogamesAPI.Models
{
    public class ConsolaModel
    {
        public int idConsola { get; set; }
        public string empresa { get; set; }
        public string nombre { get; set; }
        public int lanzamiento { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
