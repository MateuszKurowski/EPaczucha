using Microsoft.EntityFrameworkCore.Migrations;

namespace EPaczucha.database.Migrations
{
    public partial class PackagesPricesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackagePrice_PackagePriceID",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackagePrice",
                table: "PackagePrice");

            migrationBuilder.RenameTable(
                name: "PackagePrice",
                newName: "PackagePrices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackagePrices",
                table: "PackagePrices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackagePrices_PackagePriceID",
                table: "Packages",
                column: "PackagePriceID",
                principalTable: "PackagePrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackagePrices_PackagePriceID",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackagePrices",
                table: "PackagePrices");

            migrationBuilder.RenameTable(
                name: "PackagePrices",
                newName: "PackagePrice");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackagePrice",
                table: "PackagePrice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackagePrice_PackagePriceID",
                table: "Packages",
                column: "PackagePriceID",
                principalTable: "PackagePrice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
