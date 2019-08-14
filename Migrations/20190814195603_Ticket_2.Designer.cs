﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaDeEstacionamentos;

namespace SistemaGestaoEstacionamentos.Migrations
{
    [DbContext(typeof(SistemaEstacionamentosContext))]
    [Migration("20190814195603_Ticket_2")]
    partial class Ticket_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SistemaDeEstacionamentos.Estacionamento", b =>
                {
                    b.Property<int>("Handle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Handle");

                    b.ToTable("Estacionamentos");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Model.Tickets", b =>
                {
                    b.Property<int>("Handle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataHoraEntrada");

                    b.Property<DateTime>("DataHoraValidacao");

                    b.Property<TimeSpan>("TempoDecorrido");

                    b.Property<DateTime>("Validade");

                    b.Property<double>("Valor");

                    b.Property<int?>("VeiculoHandle");

                    b.HasKey("Handle");

                    b.HasIndex("VeiculoHandle");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Model.Veiculos", b =>
                {
                    b.Property<int>("Handle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo");

                    b.Property<int?>("MotoristaHandle");

                    b.Property<string>("Placa");

                    b.Property<string>("TipoDoCarro");

                    b.HasKey("Handle");

                    b.HasIndex("MotoristaHandle");

                    b.ToTable("Veiculos");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Usuarios", b =>
                {
                    b.Property<int>("Handle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cep");

                    b.Property<string>("Cpf");

                    b.Property<string>("Nome");

                    b.Property<int?>("carroPadraoHandle");

                    b.Property<string>("nomeDeUsuario");

                    b.Property<string>("senha");

                    b.HasKey("Handle");

                    b.HasIndex("carroPadraoHandle");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Vagas", b =>
                {
                    b.Property<int>("Handle")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EstacionamentoHandle");

                    b.Property<string>("LocalDaVaga");

                    b.Property<string>("TipoDaVaga");

                    b.HasKey("Handle");

                    b.HasIndex("EstacionamentoHandle");

                    b.ToTable("Vagas");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Model.Tickets", b =>
                {
                    b.HasOne("SistemaDeEstacionamentos.Model.Veiculos", "Veiculo")
                        .WithMany()
                        .HasForeignKey("VeiculoHandle");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Model.Veiculos", b =>
                {
                    b.HasOne("SistemaDeEstacionamentos.Usuarios", "Motorista")
                        .WithMany("Carros")
                        .HasForeignKey("MotoristaHandle");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Usuarios", b =>
                {
                    b.HasOne("SistemaDeEstacionamentos.Model.Veiculos", "carroPadrao")
                        .WithMany()
                        .HasForeignKey("carroPadraoHandle");
                });

            modelBuilder.Entity("SistemaDeEstacionamentos.Vagas", b =>
                {
                    b.HasOne("SistemaDeEstacionamentos.Estacionamento")
                        .WithMany("VagasDoEstacionamento")
                        .HasForeignKey("EstacionamentoHandle");
                });
#pragma warning restore 612, 618
        }
    }
}
