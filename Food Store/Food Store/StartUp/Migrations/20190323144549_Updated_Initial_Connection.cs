using Microsoft.EntityFrameworkCore.Migrations;

namespace StartUp.Migrations
{
    public partial class Updated_Initial_Connection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Post_Blog",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StoreId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "Product_StoreId",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Product_StoreId",
                table: "Products",
                column: "Product_StoreId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Employee_Store",
                table: "Employees",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Product_Store",
                table: "Products",
                column: "Product_StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Employee_Store",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "ForeignKey_Product_Store",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Product_StoreId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Product_StoreId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "ForeignKey_Post_Blog",
                table: "Employees",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
