using Microsoft.EntityFrameworkCore.Migrations;

namespace EPaczucha.database.Migrations
{
    public partial class PackagesTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackageType_PackageTypeID",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackageType",
                table: "PackageType");

            migrationBuilder.RenameTable(
                name: "PackageType",
                newName: "PackagesTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackagesTypes",
                table: "PackagesTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackagesTypes_PackageTypeID",
                table: "Packages",
                column: "PackageTypeID",
                principalTable: "PackagesTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_PackagesTypes_PackageTypeID",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackagesTypes",
                table: "PackagesTypes");

            migrationBuilder.RenameTable(
                name: "PackagesTypes",
                newName: "PackageType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackageType",
                table: "PackageType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_PackageType_PackageTypeID",
                table: "Packages",
                column: "PackageTypeID",
                principalTable: "PackageType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
