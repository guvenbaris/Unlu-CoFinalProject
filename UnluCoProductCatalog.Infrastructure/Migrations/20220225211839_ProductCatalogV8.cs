using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UnluCoProductCatalog.Infrastructure.Migrations
{
    public partial class ProductCatalogV8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "Products");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Image",
                table: "Products",
                type: "varbinary(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(MAX)");

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "Products",
                type: "int",
                nullable: true);
        }
    }
}
