using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Propietaria2_2doRetro.Models;

namespace Propietaria2_2doRetro.Data.EfCore
{
    public class MDBContext : DbContext
    {
        public MDBContext (DbContextOptions<MDBContext> options)
            : base(options)
        {
        }

        public DbSet<Actor> Actor { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<Clasificacion> Clasificacion { get; set; }
        public DbSet<Director> Director { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Studio> Estudio { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Lenguaje> Lenguaje { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Actor>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

            modelBuilder.Entity<Cast>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

            modelBuilder.Entity<Clasificacion>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

            modelBuilder.Entity<Director>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

            modelBuilder.Entity<Genero>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

            modelBuilder.Entity<Lenguaje>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

            modelBuilder.Entity<Movie>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);            

            modelBuilder.Entity<Pais>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

            modelBuilder.Entity<Studio>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

            modelBuilder.Entity<User>()
                .Property(p => p.Activo)
                .HasDefaultValue(true);

        }
    }
}
