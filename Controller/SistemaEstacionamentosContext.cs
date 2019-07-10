using Microsoft.EntityFrameworkCore;
using System;

namespace SistemaDeEstacionamentos
{
    internal class SistemaEstacionamentosContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(postgreSQL)\\mssqllocaldb;Database=SistemaGestaoEstacionamentos;Trusted_Connection=true;");
        }
    }
}