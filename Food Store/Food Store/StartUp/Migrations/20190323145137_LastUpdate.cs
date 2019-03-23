using Microsoft.EntityFrameworkCore.Migrations;

namespace StartUp.Migrations
{
    public partial class LastUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Product_StoreId",
                table: "Products",
                newName: "ProductStoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_Product_StoreId",
                table: "Products",
                newName: "IX_Products_ProductStoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductStoreId",
                table: "Products",
                newName: "Product_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductStoreId",
                table: "Products",
                newName: "IX_Products_Product_StoreId");
        }
    }
}
