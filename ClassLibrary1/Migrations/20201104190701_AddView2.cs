using Microsoft.EntityFrameworkCore.Migrations;

namespace Departments.Migrations
{
    public partial class AddView2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"create view SubjectStats as 
select COUNT(ss.StudentId) num, s.Name name
from StudentSubject ss join Subject s 
on (s.SubjectId=ss.SubjectId)
group by s.Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view SubjectStats");
        }
    }
}
