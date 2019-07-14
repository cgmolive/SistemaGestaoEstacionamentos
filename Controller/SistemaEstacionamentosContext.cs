using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamentos.Model;
using System;

namespace SistemaDeEstacionamentos
{
    internal class SistemaEstacionamentosContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }

        public DbSet<Tickets> Tickets { get; set;  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("User ID=root;Password=Cassius@@1;Host=localhost;Port=5432;Database=SistemaGestaoEstacionamentos;Pooling = true; Min Pool Size = 0; Max Pool Size = 100; Connection Lifetime = 0; ");
        }
    }
}