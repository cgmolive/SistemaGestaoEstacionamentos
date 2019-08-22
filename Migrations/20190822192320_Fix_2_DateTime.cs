﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaGestaoEstacionamentos.Migrations
{
    public partial class Fix_2_DateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Validade",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(TimeSpan));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Validade",
                table: "Tickets",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
