using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Patrimonio.Migrations
{
    /// <inheritdoc />
    public partial class TabelaEmprestimo2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAbertura",
                table: "Emprestimo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFechamento",
                table: "Emprestimo",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Observacao",
                table: "Emprestimo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Situacao",
                table: "Emprestimo",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAbertura",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "DataFechamento",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "Observacao",
                table: "Emprestimo");

            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Emprestimo");
        }
    }
}
