using Microsoft.EntityFrameworkCore;
using System;

namespace SistemaDeEstacionamentos
{
    internal class UsuariosContext : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}