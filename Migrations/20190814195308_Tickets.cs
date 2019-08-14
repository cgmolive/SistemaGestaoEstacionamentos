using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaGestaoEstacionamentos.Migrations
{
    public partial class Tickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    Handle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.Handle);
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Handle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TipoDaVaga = table.Column<string>(nullable: true),
                    LocalDaVaga = table.Column<string>(nullable: true),
                    EstacionamentoHandle = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Handle);
                    table.ForeignKey(
                        name: "FK_Vagas_Estacionamentos_EstacionamentoHandle",
                        column: x => x.EstacionamentoHandle,
                        principalTable: "Estacionamentos",
                        principalColumn: "Handle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Handle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: true),
                    TipoDoCarro = table.Column<string>(nullable: true),
                    MotoristaHandle = table.Column<int>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Handle);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Handle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(nullable: false),
                    Validade = table.Column<DateTime>(nullable: false),
                    DataHoraValidacao = table.Column<DateTime>(nullable: false),
                    TempoDecorrido = table.Column<TimeSpan>(nullable: false),
                    VeiculoHandle = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Handle);
                    table.ForeignKey(
                        name: "FK_Tickets_Veiculos_VeiculoHandle",
                        column: x => x.VeiculoHandle,
                        principalTable: "Veiculos",
                        principalColumn: "Handle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Handle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cpf = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Cep = table.Column<int>(nullable: false),
                    nomeDeUsuario = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    carroPadraoHandle = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Handle);
                    table.ForeignKey(
                        name: "FK_Usuarios_Veiculos_carroPadraoHandle",
                        column: x => x.carroPadraoHandle,
                        principalTable: "Veiculos",
                        principalColumn: "Handle",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_VeiculoHandle",
                table: "Tickets",
                column: "VeiculoHandle");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_carroPadraoHandle",
                table: "Usuarios",
                column: "carroPadraoHandle");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_EstacionamentoHandle",
                table: "Vagas",
                column: "EstacionamentoHandle");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_MotoristaHandle",
                table: "Veiculos",
                column: "MotoristaHandle");

            migrationBuilder.AddForeignKey(
                name: "FK_Veiculos_Usuarios_MotoristaHandle",
                table: "Veiculos",
                column: "MotoristaHandle",
                principalTable: "Usuarios",
                principalColumn: "Handle",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Veiculos_carroPadraoHandle",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Estacionamentos");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
