﻿namespace videogamesAPI.Models
{
    public class JuegosModel
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
        public DateTime? created_at { get; set; }
        public DateTime? updated_at { get; set; }

    }
}
