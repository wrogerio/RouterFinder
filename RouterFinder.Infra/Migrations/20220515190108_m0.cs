using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RouterFinder.Infra.Migrations
{
    public partial class m0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    routeFrom = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    routeTo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    routeValue = table.Column<double>(type: "float", nullable: false, defaultValue: 0.0),
                    routeDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Routes",
                columns: new[] { "Id", "routeDescription", "routeFrom", "routeTo", "routeValue" },
                values: new object[,]
                {
                    { new Guid("a4639706-7262-4731-81cb-17398bc7f9d6"), "GRU -> BRC", "GRU", "BRC", 10.0 },
                    { new Guid("c806da72-a078-432b-ac1b-2e85cf711e5e"), "GRU -> CDG", "GRU", "CDG", 75.0 },
                    { new Guid("fdd84c1e-aada-4eb8-a404-ae46298ff6b6"), "GRU -> SCL", "GRU", "SCL", 20.0 },
                    { new Guid("8a4e2ceb-7da8-475a-a42a-e14de554e4b3"), "GRU -> ORL", "GRU", "ORL", 56.0 },
                    { new Guid("78f9678b-3a82-4740-a96a-6d3f84019b45"), "BRC -> SCL", "BRC", "SCL", 5.0 },
                    { new Guid("b4032e1e-9fbd-4292-93a7-15282df694bd"), "ORL -> CDG", "ORL", "CDG", 5.0 },
                    { new Guid("42fdc1d8-2389-476a-8390-41ab769bf02d"), "SCL -> ORL", "SCL", "ORL", 20.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Routes");
        }
    }
}
