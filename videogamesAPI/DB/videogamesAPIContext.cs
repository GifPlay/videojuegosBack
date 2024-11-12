using Microsoft.EntityFrameworkCore;
using System.Xml;
using videogamesAPI.DB;
using videogamesAPI.DB.Entities;


namespace videogamesAPI.DB
{
    public class videogamesAPIContext : DbContext
    {

        public videogamesAPIContext(DbContextOptions<videogamesAPIContext> options) : base(options) { }

        public DbSet<Entities.Juegos> Juegos { get; set; }
        public DbSet<Entities.Consolas> Consolas { get; set; }
        public DbSet<Entities.Clasificacion> Clasificacion { get; set; }
        public DbSet<Entities.Generos> Generos { get; set; }
        public DbSet<Entities.JuegoGenero> JuegoGenero { get; set; }
        public DbSet<Entities.ViewJuegosConsola> ViewJuegosConsola { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewJuegosConsola>().HasNoKey().ToView("view_juegos_consola_clasificacion");
        }

    }
}
