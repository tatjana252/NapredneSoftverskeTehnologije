using Microsoft.EntityFrameworkCore.Migrations;

namespace Departments.Migrations
{
    public partial class ChangeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Departments_DepartmentId",
                table: "Subject");

            migrationBuilder.DropColumn(
                name: "DepratmentId",
                table: "Subject");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Subject",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Departments_DepartmentId",
                table: "Subject",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_Departments_DepartmentId",
                table: "Subject");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Subject",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "DepratmentId",
                table: "Subject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_Departments_DepartmentId",
                table: "Subject",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
