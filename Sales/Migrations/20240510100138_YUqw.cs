using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Migrations
{
    /// <inheritdoc />
    public partial class YUqw : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumbers_Orders_OId",
                table: "SerialNumbers");

            migrationBuilder.DropIndex(
                name: "IX_SerialNumbers_OId",
                table: "SerialNumbers");

            migrationBuilder.DropColumn(
                name: "OId",
                table: "SerialNumbers");

            migrationBuilder.AddColumn<int>(
                name: "OrderOId",
                table: "SerialNumbers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_OrderOId",
                table: "SerialNumbers",
                column: "OrderOId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumbers_Orders_OrderOId",
                table: "SerialNumbers",
                column: "OrderOId",
                principalTable: "Orders",
                principalColumn: "OId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumbers_Orders_OrderOId",
                table: "SerialNumbers");

            migrationBuilder.DropIndex(
                name: "IX_SerialNumbers_OrderOId",
                table: "SerialNumbers");

            migrationBuilder.DropColumn(
                name: "OrderOId",
                table: "SerialNumbers");

            migrationBuilder.AddColumn<int>(
                name: "OId",
                table: "SerialNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_OId",
                table: "SerialNumbers",
                column: "OId");

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumbers_Orders_OId",
                table: "SerialNumbers",
                column: "OId",
                principalTable: "Orders",
                principalColumn: "OId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
