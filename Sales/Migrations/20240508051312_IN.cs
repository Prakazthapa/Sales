using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Migrations
{
    /// <inheritdoc />
    public partial class IN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumbers_Products_PId",
                table: "SerialNumbers");

            migrationBuilder.DropIndex(
                name: "IX_SerialNumbers_PId",
                table: "SerialNumbers");

            migrationBuilder.DropColumn(
                name: "PId",
                table: "SerialNumbers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PId",
                table: "SerialNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumbers_PId",
                table: "SerialNumbers",
                column: "PId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumbers_Products_PId",
                table: "SerialNumbers",
                column: "PId",
                principalTable: "Products",
                principalColumn: "PId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
