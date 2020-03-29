using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMVc.Migrations
{
    public partial class DepartmentForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "Sellers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "Sellers");
        }
    }
}
