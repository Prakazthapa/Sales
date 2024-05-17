using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Migrations
{
    /// <inheritdoc />
    public partial class OUTt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ODate",
                table: "Orders");

            migrationBuilder.AddColumn<DateTime>(
                name: "ODateTime",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SerialNumberId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_SerialNumberId",
                table: "Orders",
                column: "SerialNumberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SerialNumbers_SerialNumberId",
                table: "Orders",
                column: "SerialNumberId",
                principalTable: "SerialNumbers",
                principalColumn: "SerialNumberId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SerialNumbers_SerialNumberId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SerialNumberId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ODateTime",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SerialNumberId",
                table: "Orders");

            migrationBuilder.AddColumn<DateOnly>(
                name: "ODate",
                table: "Orders",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
