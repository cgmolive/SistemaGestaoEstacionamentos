using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaGestaoEstacionamentos.Migrations
{
    public partial class teste3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cep",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "nomeDeUsuario",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "senha",
                table: "Usuarios",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "cep",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "nomeDeUsuario",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "senha",
                table: "Usuarios");
        }
    }
}
