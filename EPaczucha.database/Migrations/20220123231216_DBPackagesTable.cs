using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPaczucha.database.Migrations
{
    public partial class DBPackagesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SimpleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PackagePriceID = table.Column<int>(type: "int", nullable: false),
                    PackageTypeID = table.Column<int>(type: "int", nullable: false),
                    SendMethodID = table.Column<int>(type: "int", nullable: false),
                    DestinationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_PackagePrices_PackagePriceID",
                        column: x => x.PackagePriceID,
                        principalTable: "PackagePrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_PackagesTypes_PackageTypeID",
                        column: x => x.PackageTypeID,
                        principalTable: "PackagesTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_SendMethods_SendMethodID",
                        column: x => x.SendMethodID,
                        principalTable: "SendMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CustomerId",
                table: "Packages",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_DestinationId",
                table: "Packages",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PackagePriceID",
                table: "Packages",
                column: "PackagePriceID");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_PackageTypeID",
                table: "Packages",
                column: "PackageTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_SendMethodID",
                table: "Packages",
                column: "SendMethodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Packages");
        }
    }
}
