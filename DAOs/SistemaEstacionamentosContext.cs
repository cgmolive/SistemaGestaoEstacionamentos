using Microsoft.EntityFrameworkCore;
using SistemaDeEstacionamentos.Model;
using System;

namespace SistemaDeEstacionamentos
{
    public class SistemaEstacionamentosContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }

        public DbSet<Tickets> Tickets { get; set; }

        public DbSet<Veiculos> Veiculos { get; set; }

        public DbSet<Vagas> Vagas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = localdb; Trusted_Connection = true; ");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>()
                .HasKey(c => c.Handle);


            modelBuilder.Entity<Usuarios>()
                .HasMany(c => c.Carros)
                .WithOne(e => e.Motorista);


            modelBuilder.Entity<Tickets>()
                .HasKey(c => c.Handle);

            modelBuilder.Entity<Estacionamento>()
                .HasKey(c => c.Handle);

            modelBuilder.Entity<Vagas>()
                .HasKey(c => c.Handle);

            modelBuilder.Entity<Veiculos>()
                .HasKey(c => c.Handle);

            modelBuilder.Entity<Tickets>()
               .HasOne(c => c.Veiculo)
               .WithMany(e => e.tickets);

            modelBuilder.Entity<Vagas>()
                .HasKey(c => c.Handle);
        }

    }
}
