using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BouquetShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buyers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Emai = table.Column<string>(type: "TEXT", nullable: false),
                    Pass = table.Column<string>(type: "TEXT", nullable: false),
                    PicUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<float>(type: "REAL", nullable: false),
                    DateOfCreate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buyers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "salesmens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Emai = table.Column<string>(type: "TEXT", nullable: false),
                    Pass = table.Column<string>(type: "TEXT", nullable: false),
                    PicUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Money = table.Column<float>(type: "REAL", nullable: false),
                    DateOfCreate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salesmens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "bouqets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<float>(type: "REAL", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false),
                    SalesmanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bouqets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bouqets_salesmens_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "salesmens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BouqetBuyer",
                columns: table => new
                {
                    BuyersId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouqetBuyer", x => new { x.BuyersId, x.CartId });
                    table.ForeignKey(
                        name: "FK_BouqetBuyer_bouqets_CartId",
                        column: x => x.CartId,
                        principalTable: "bouqets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouqetBuyer_buyers_BuyersId",
                        column: x => x.BuyersId,
                        principalTable: "buyers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouqetBuyer_CartId",
                table: "BouqetBuyer",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_bouqets_SalesmanId",
                table: "bouqets",
                column: "SalesmanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouqetBuyer");

            migrationBuilder.DropTable(
                name: "bouqets");

            migrationBuilder.DropTable(
                name: "buyers");

            migrationBuilder.DropTable(
                name: "salesmens");
        }
    }
}
