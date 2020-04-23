using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Desafios_academy.Migrations
{
    public partial class AddReflectionToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReflectionsItems",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReflectionsItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReflectionsItems");
        }
    }
}
