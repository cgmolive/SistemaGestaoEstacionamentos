using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using SistemaDeEstacionamentos;

namespace SistemaDeEstacionamentos.Migrations
{
    [DbContext(typeof(SistemaEstacionamentosContext))]
    partial class SistemaEstacionamentosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaDeEstacionamentos.Estacionamento", b =>
                {
                    b.Property<int>("Handle")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Handle");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Model.Tickets", b =>
                {
                    b.Property<int>("Handle")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Handle");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Usuarios", b =>
                {
                    b.Property<int>("Handle")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Handle");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Vagas", b =>
                {
                    b.Property<int>("Handle")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EstacionamentoHandle");

                    b.Property<string>("LocalDaVaga");

                    b.Property<string>("TipoDaVaga");

                    b.HasKey("Handle");

                    b.HasIndex("EstacionamentoHandle");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Vagas", b =>
                {
                    b.HasOne("SistemaDeEstacionamentos.Estacionamento")
                        .WithMany("VagasDoEstacionamento")
                        .HasForeignKey("EstacionamentoHandle");
                });
        }
    }
}
