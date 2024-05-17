using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Migrations
{
    /// <inheritdoc />
    public partial class No : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SerialNumbers_SerialNumberId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_SerialNumberId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "SerialNumberId",
                table: "Orders",
                newName: "Quantity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Orders",
                newName: "SerialNumberId");

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
                onDelete: ReferentialAction.Cascade);
        }
    }
}
