using Microsoft.EntityFrameworkCore;
using System;

namespace SistemaDeEstacionamentos
{
    internal class UsuariosContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(postgreSQL)\\mssqllocaldb;Database=SistemaGestaoEstacionamentos;Trusted_Connection=true;");
        }
    }
}