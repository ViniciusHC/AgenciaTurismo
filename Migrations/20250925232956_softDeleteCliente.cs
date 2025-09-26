using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgenciaTurismo.Migrations
{
    /// <inheritdoc />
    public partial class softDeleteCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                table: "Clientes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Clientes");
        }
    }
}
