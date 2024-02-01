using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRINTest.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UnitMeasurement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Count = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Products__3213E83F0F5A9EF5", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BuyingProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: true),
                    placementDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    ClientNavigationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BuyingPr__3213E83F1BF030E1", x => x.id);
                    table.ForeignKey(
                        name: "FK_BuyingProducts_Clients_ClientNavigationId",
                        column: x => x.ClientNavigationId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products_ByuingProducts",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProduct = table.Column<int>(type: "int", nullable: true),
                    idByuingProduct = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__3213E83F83D91EEE", x => x.id);
                    table.ForeignKey(
                        name: "FK__Orders__buyingPr__3B75D760",
                        column: x => x.idByuingProduct,
                        principalTable: "BuyingProducts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Orders__productI__3A81B327",
                        column: x => x.idProduct,
                        principalTable: "Products",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyingProducts_ClientNavigationId",
                table: "BuyingProducts",
                column: "ClientNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ByuingProducts_idByuingProduct",
                table: "Products_ByuingProducts",
                column: "idByuingProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ByuingProducts_idProduct",
                table: "Products_ByuingProducts",
                column: "idProduct");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products_ByuingProducts");

            migrationBuilder.DropTable(
                name: "BuyingProducts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
