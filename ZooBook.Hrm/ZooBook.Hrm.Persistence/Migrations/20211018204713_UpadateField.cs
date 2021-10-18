using Microsoft.EntityFrameworkCore.Migrations;

namespace ZooBook.Hrm.Persistence.Migrations
{
    public partial class UpadateField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MidddleName",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "Employee",
                maxLength: 400,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "MidddleName",
                table: "Employee",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: true);
        }
    }
}
