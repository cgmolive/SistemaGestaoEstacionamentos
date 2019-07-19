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


        public DbSet<Veiculos> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("User ID=root;Password=Cassius@@1;Host=localhost;Port=5432;Database=SistemaGestaoEstacionamentos;Pooling = true; Min Pool Size = 0; Max Pool Size = 100; Connection Lifetime = 0; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .HasKey(c =>c.Handle);

            modelBuilder.Entity<Tickets>()
                .HasKey(c =>c.Handle);

            modelBuilder.Entity<Estacionamento>()
                .HasKey(c =>c.Handle);

            modelBuilder.Entity<Vagas>()
                .HasKey(c => c.Handle);

            modelBuilder.Entity<Veiculos>()
                .HasKey(c => c.Handle);
        }
    }
}