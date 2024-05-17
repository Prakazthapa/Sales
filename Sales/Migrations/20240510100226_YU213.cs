using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Migrations
{
    /// <inheritdoc />
    public partial class YU213 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumbers_Orders_OrderOId",
                table: "SerialNumbers");

            migrationBuilder.RenameColumn(
                name: "OrderOId",
                table: "SerialNumbers",
                newName: "OId");

            migrationBuilder.RenameIndex(
                name: "IX_SerialNumbers_OrderOId",
                table: "SerialNumbers",
                newName: "IX_SerialNumbers_OId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumbers_Orders_OId",
                table: "SerialNumbers",
                column: "OId",
                principalTable: "Orders",
                principalColumn: "OId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumbers_Orders_OId",
                table: "SerialNumbers");

            migrationBuilder.RenameColumn(
                name: "OId",
                table: "SerialNumbers",
                newName: "OrderOId");

            migrationBuilder.RenameIndex(
                name: "IX_SerialNumbers_OId",
                table: "SerialNumbers",
                newName: "IX_SerialNumbers_OrderOId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumbers_Orders_OrderOId",
                table: "SerialNumbers",
                column: "OrderOId",
                principalTable: "Orders",
                principalColumn: "OId");
        }
    }
}
