using Microsoft.EntityFrameworkCore.Migrations;

namespace EPaczucha.database.Migrations
{
    public partial class SendMethodTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_SendMethod_SendMethodID",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SendMethod",
                table: "SendMethod");

            migrationBuilder.RenameTable(
                name: "SendMethod",
                newName: "SendMethods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendMethods",
                table: "SendMethods",
                column: "SendMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_SendMethods_SendMethodID",
                table: "Packages",
                column: "SendMethodID",
                principalTable: "SendMethods",
                principalColumn: "SendMethodId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Packages_SendMethods_SendMethodID",
                table: "Packages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SendMethods",
                table: "SendMethods");

            migrationBuilder.RenameTable(
                name: "SendMethods",
                newName: "SendMethod");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SendMethod",
                table: "SendMethod",
                column: "SendMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_SendMethod_SendMethodID",
                table: "Packages",
                column: "SendMethodID",
                principalTable: "SendMethod",
                principalColumn: "SendMethodId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
