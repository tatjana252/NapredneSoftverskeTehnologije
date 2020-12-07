using Microsoft.EntityFrameworkCore.Migrations;

namespace Departments.Migrations
{
    public partial class DropContentIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content_ContentId",
                table: "SubjectItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Content_ContentId",
                table: "SubjectItem",
                type: "int",
                nullable: true);
        }
    }
}
