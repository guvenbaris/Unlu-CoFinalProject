using Microsoft.EntityFrameworkCore.Migrations;

namespace UnluCoProductCatalog.Infrastructure.Migrations
{
    public partial class ProductCatalogV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Products_ProductId",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Offers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Products_ProductId",
                table: "Offers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Products_ProductId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Products_ProductId",
                table: "Offers",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
