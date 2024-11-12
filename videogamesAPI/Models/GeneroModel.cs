namespace videogamesAPI.Models
{
    public class GeneroModel
    {
        public int ?idGenero { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
