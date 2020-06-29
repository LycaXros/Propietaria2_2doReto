using Microsoft.EntityFrameworkCore;
using System;

namespace Reto2.Datos
{
    public class DbContextMovies : DbContext
    {
        public DbContextMovies(DbContextOptions<DbContextMovies> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
