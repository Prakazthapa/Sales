using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sales.Migrations
{
    /// <inheritdoc />
    public partial class newtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistrictId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalBodyId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceId",
                table: "Customers",
                type: "int",
                nullable: true);

            //migrationBuilder.CreateTable(
            //    name: "Province",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
            //        NameNp = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
            //        IMUCode = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Province", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "District",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ProvinceId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
            //        NameNp = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
            //        DisplayOrder = table.Column<int>(type: "int", nullable: false),
            //        IMUCode = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_District", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_District_Province_ProvinceId",
            //            column: x => x.ProvinceId,
            //            principalTable: "Province",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "LocalBody",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        DistrictId = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        NameNp = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
            //        IsMunicipality = table.Column<bool>(type: "bit", nullable: false),
            //        DisplayOrder = table.Column<int>(type: "int", nullable: false),
            //        IMUCode = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_LocalBody", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_LocalBody_District_DistrictId",
            //            column: x => x.DistrictId,
            //            principalTable: "District",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_DistrictId",
                table: "Customers",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LocalBodyId",
                table: "Customers",
                column: "LocalBodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ProvinceId",
                table: "Customers",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_District_ProvinceId",
                table: "District",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalBody_DistrictId",
                table: "LocalBody",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_District_DistrictId",
                table: "Customers",
                column: "DistrictId",
                principalTable: "District",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_LocalBody_LocalBodyId",
                table: "Customers",
                column: "LocalBodyId",
                principalTable: "LocalBody",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Province_ProvinceId",
                table: "Customers",
                column: "ProvinceId",
                principalTable: "Province",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_District_DistrictId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_LocalBody_LocalBodyId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Province_ProvinceId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "LocalBody");

            migrationBuilder.DropTable(
                name: "District");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropIndex(
                name: "IX_Customers_DistrictId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_LocalBodyId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ProvinceId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "DistrictId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LocalBodyId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ProvinceId",
                table: "Customers");
        }
    }
}
