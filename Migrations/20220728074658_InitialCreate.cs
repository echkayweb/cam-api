﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cam_api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Pincode = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DOJ = table.Column<DateTime>(type: "Date", nullable: false),
                    EOJ = table.Column<DateTime>(type: "Date", nullable: true),
                    Phone = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    AssetModel = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    AssetSerialNumber = table.Column<string>(type: "nvarchar(30)", nullable: false),
                    AssetAvailable = table.Column<int>(type: "int", nullable: false),
                    AssignedAssetId = table.Column<int>(type: "int", nullable: true),
                    AssetAssignedTo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                    table.ForeignKey(
                        name: "FK_Assets_Employees_AssetAssignedTo",
                        column: x => x.AssetAssignedTo,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateTable(
                name: "AssignedAssets",
                columns: table => new
                {
                    AssignedAssetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssetId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DateAssigned = table.Column<DateTime>(type: "Date", nullable: false),
                    DateReturned = table.Column<DateTime>(type: "Date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignedAssets", x => x.AssignedAssetId);
                    table.ForeignKey(
                        name: "FK_AssignedAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId");
                    table.ForeignKey(
                        name: "FK_AssignedAssets_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssetAssignedTo",
                table: "Assets",
                column: "AssetAssignedTo");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_AssignedAssetId",
                table: "Assets",
                column: "AssignedAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedAssets_AssetId",
                table: "AssignedAssets",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignedAssets_EmployeeId",
                table: "AssignedAssets",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assets_AssignedAssets_AssignedAssetId",
                table: "Assets",
                column: "AssignedAssetId",
                principalTable: "AssignedAssets",
                principalColumn: "AssignedAssetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assets_AssignedAssets_AssignedAssetId",
                table: "Assets");

            migrationBuilder.DropTable(
                name: "AssignedAssets");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
