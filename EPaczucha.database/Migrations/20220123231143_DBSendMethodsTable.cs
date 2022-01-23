using Microsoft.EntityFrameworkCore.Migrations;

namespace EPaczucha.database.Migrations
{
    public partial class DBSendMethodsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SendMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendMethods", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SendMethods");
        }
    }
}
