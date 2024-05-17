using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Migrations
{
    /// <inheritdoc />
    public partial class YU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OId",
                table: "SerialNumbers",
                type: "int",
                nullable: true,
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
