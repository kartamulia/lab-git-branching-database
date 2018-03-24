using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Lab.GBD.Entities.Data.Migrations
{
    public partial class Unit_Of_Measurement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UnitOfMeasure",
                table: "InventoryItems",
                newName: "UnitOfMeasurementId");

            migrationBuilder.CreateTable(
                name: "UnitOfMeasurements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasurements", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_UnitOfMeasurementId",
                table: "InventoryItems",
                column: "UnitOfMeasurementId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_UnitOfMeasurements_UnitOfMeasurementId",
                table: "InventoryItems",
                column: "UnitOfMeasurementId",
                principalTable: "UnitOfMeasurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_UnitOfMeasurements_UnitOfMeasurementId",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "UnitOfMeasurements");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_UnitOfMeasurementId",
                table: "InventoryItems");

            migrationBuilder.RenameColumn(
                name: "UnitOfMeasurementId",
                table: "InventoryItems",
                newName: "UnitOfMeasure");
        }
    }
}
