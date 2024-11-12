namespace videogamesAPI.Models
{
    public class ClasificacionModel
    {
        public int idClasificacion { get; set; }
        public string clasificacion { get; set; }
        public int edad { get; set; }
        public string descripcion { get; set; }
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }
    }
}
