using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaGestaoEstacionamentos.Migrations
{
    public partial class Nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estacionamentos",
                columns: table => new
                {
                    Handle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Carencia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estacionamentos", x => x.Handle);
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
                    carroPadraoId = table.Column<long>(nullable: false),
                    Logradouro = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Handle);
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
                    Handle = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Placa = table.Column<string>(nullable: true),
                    TipoDoCarro = table.Column<string>(nullable: true),
                    MotoristaId = table.Column<int>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Handle);
                    table.ForeignKey(
                        name: "FK_Veiculos_Usuarios_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Usuarios",
                        principalColumn: "Handle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Handle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Valor = table.Column<double>(nullable: false),
                    DataHoraEntrada = table.Column<DateTime>(nullable: false),
                    Validade = table.Column<DateTime>(nullable: false),
                    DataHoraValidacao = table.Column<DateTime>(nullable: false),
                    TempoDecorrido = table.Column<TimeSpan>(nullable: false),
                    VeiculoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Handle);
                    table.ForeignKey(
                        name: "FK_Tickets_Veiculos_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "Veiculos",
                        principalColumn: "Handle",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_VeiculoId",
                table: "Tickets",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_EstacionamentoHandle",
                table: "Vagas",
                column: "EstacionamentoHandle");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculos_MotoristaId",
                table: "Veiculos",
                column: "MotoristaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Veiculos");

            migrationBuilder.DropTable(
                name: "Estacionamentos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
