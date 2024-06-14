using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vylex.Data.Migrations
{
    public partial class correcaoEvaluetion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evaluetion_Course_CoursesId",
                table: "Evaluetion");

            migrationBuilder.DropForeignKey(
                name: "FK_Evaluetion_Student_StudentsId",
                table: "Evaluetion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluetion_CoursesId",
                table: "Evaluetion");

            migrationBuilder.DropIndex(
                name: "IX_Evaluetion_StudentsId",
                table: "Evaluetion");

            migrationBuilder.DropColumn(
                name: "CoursesId",
                table: "Evaluetion");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Evaluetion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoursesId",
                table: "Evaluetion",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Evaluetion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Evaluetion_CoursesId",
                table: "Evaluetion",
                column: "CoursesId");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluetion_StudentsId",
                table: "Evaluetion",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluetion_Course_CoursesId",
                table: "Evaluetion",
                column: "CoursesId",
                principalTable: "Course",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Evaluetion_Student_StudentsId",
                table: "Evaluetion",
                column: "StudentsId",
                principalTable: "Student",
                principalColumn: "Id");
        }
    }
}
