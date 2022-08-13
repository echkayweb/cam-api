using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cam_api.Migrations
{
    public partial class AddAssetProps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Assets",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Assets",
                type: "Date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Warranty",
                table: "Assets",
                type: "nvarchar(30)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Assets");

            migrationBuilder.DropColumn(
                name: "Warranty",
                table: "Assets");
        }
    }
}
