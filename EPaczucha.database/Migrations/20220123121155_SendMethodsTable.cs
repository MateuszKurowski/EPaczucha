using Microsoft.EntityFrameworkCore.Migrations;

namespace EPaczucha.database.Migrations
{
    public partial class SendMethodsTable : Migration
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
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_SendMethods_SendMethodID",
                table: "Packages",
                column: "SendMethodID",
                principalTable: "SendMethods",
                principalColumn: "Id",
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
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Packages_SendMethod_SendMethodID",
                table: "Packages",
                column: "SendMethodID",
                principalTable: "SendMethod",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
