using Microsoft.EntityFrameworkCore.Migrations;

namespace UnluCoProductCatalog.Infrastructure.Migrations
{
    public partial class PCV6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDetails_AspNetUsers_UserId",
                table: "AccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AccountDetails_AccountDetailId",
                table: "Offers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AccountDetails_AccountDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_AccountDetailId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Offers_AccountDetailId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_AccountDetails_UserId",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "AccountDetailId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "AccountDetailId",
                table: "Offers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AccountDetails",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "AccountDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "AccountDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetails_OfferId",
                table: "AccountDetails",
                column: "OfferId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetails_ProductId",
                table: "AccountDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetails_UserId",
                table: "AccountDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDetails_AspNetUsers_UserId",
                table: "AccountDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDetails_Offers_OfferId",
                table: "AccountDetails",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDetails_Products_ProductId",
                table: "AccountDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountDetails_AspNetUsers_UserId",
                table: "AccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountDetails_Offers_OfferId",
                table: "AccountDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountDetails_Products_ProductId",
                table: "AccountDetails");

            migrationBuilder.DropIndex(
                name: "IX_AccountDetails_OfferId",
                table: "AccountDetails");

            migrationBuilder.DropIndex(
                name: "IX_AccountDetails_ProductId",
                table: "AccountDetails");

            migrationBuilder.DropIndex(
                name: "IX_AccountDetails_UserId",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "AccountDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "AccountDetails");

            migrationBuilder.AddColumn<int>(
                name: "AccountDetailId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountDetailId",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "AccountDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_AccountDetailId",
                table: "Products",
                column: "AccountDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_AccountDetailId",
                table: "Offers",
                column: "AccountDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountDetails_UserId",
                table: "AccountDetails",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountDetails_AspNetUsers_UserId",
                table: "AccountDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AccountDetails_AccountDetailId",
                table: "Offers",
                column: "AccountDetailId",
                principalTable: "AccountDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AccountDetails_AccountDetailId",
                table: "Products",
                column: "AccountDetailId",
                principalTable: "AccountDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
