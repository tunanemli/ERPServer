using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPServer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Depot",
                table: "Depot");

            migrationBuilder.RenameTable(
                name: "Depot",
                newName: "Depots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depots",
                table: "Depots",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Depots",
                table: "Depots");

            migrationBuilder.RenameTable(
                name: "Depots",
                newName: "Depot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Depot",
                table: "Depot",
                column: "Id");
        }
    }
}
