using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SCRINTest.Migrations
{
    /// <inheritdoc />
    public partial class recreateTable5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Orders__buyingPr__3B75D760",
                table: "Products_ByuingProducts");

            migrationBuilder.DropForeignKey(
                name: "FK__Orders__productI__3A81B327",
                table: "Products_ByuingProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Orders__3213E83F83D91EEE",
                table: "Products_ByuingProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ByuingProducts_idByuingProduct",
                table: "Products_ByuingProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ByuingProducts_idProduct",
                table: "Products_ByuingProducts");

            migrationBuilder.RenameTable(
                name: "Products_ByuingProducts",
                newName: "ProductsByuingProducts");

            migrationBuilder.RenameColumn(
                name: "idProduct",
                table: "ProductsByuingProducts",
                newName: "IdProduct");

            migrationBuilder.RenameColumn(
                name: "idByuingProduct",
                table: "ProductsByuingProducts",
                newName: "IdByuingProduct");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ProductsByuingProducts",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ByuingProductNavigationId",
                table: "ProductsByuingProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductNavigationId",
                table: "ProductsByuingProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductsByuingProducts",
                table: "ProductsByuingProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsByuingProducts_ByuingProductNavigationId",
                table: "ProductsByuingProducts",
                column: "ByuingProductNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsByuingProducts_ProductNavigationId",
                table: "ProductsByuingProducts",
                column: "ProductNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsByuingProducts_BuyingProducts_ByuingProductNavigationId",
                table: "ProductsByuingProducts",
                column: "ByuingProductNavigationId",
                principalTable: "BuyingProducts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductsByuingProducts_Products_ProductNavigationId",
                table: "ProductsByuingProducts",
                column: "ProductNavigationId",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductsByuingProducts_BuyingProducts_ByuingProductNavigationId",
                table: "ProductsByuingProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductsByuingProducts_Products_ProductNavigationId",
                table: "ProductsByuingProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductsByuingProducts",
                table: "ProductsByuingProducts");

            migrationBuilder.DropIndex(
                name: "IX_ProductsByuingProducts_ByuingProductNavigationId",
                table: "ProductsByuingProducts");

            migrationBuilder.DropIndex(
                name: "IX_ProductsByuingProducts_ProductNavigationId",
                table: "ProductsByuingProducts");

            migrationBuilder.DropColumn(
                name: "ByuingProductNavigationId",
                table: "ProductsByuingProducts");

            migrationBuilder.DropColumn(
                name: "ProductNavigationId",
                table: "ProductsByuingProducts");

            migrationBuilder.RenameTable(
                name: "ProductsByuingProducts",
                newName: "Products_ByuingProducts");

            migrationBuilder.RenameColumn(
                name: "IdProduct",
                table: "Products_ByuingProducts",
                newName: "idProduct");

            migrationBuilder.RenameColumn(
                name: "IdByuingProduct",
                table: "Products_ByuingProducts",
                newName: "idByuingProduct");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products_ByuingProducts",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Orders__3213E83F83D91EEE",
                table: "Products_ByuingProducts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ByuingProducts_idByuingProduct",
                table: "Products_ByuingProducts",
                column: "idByuingProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ByuingProducts_idProduct",
                table: "Products_ByuingProducts",
                column: "idProduct");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__buyingPr__3B75D760",
                table: "Products_ByuingProducts",
                column: "idByuingProduct",
                principalTable: "BuyingProducts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__productI__3A81B327",
                table: "Products_ByuingProducts",
                column: "idProduct",
                principalTable: "Products",
                principalColumn: "id");
        }
    }
}
