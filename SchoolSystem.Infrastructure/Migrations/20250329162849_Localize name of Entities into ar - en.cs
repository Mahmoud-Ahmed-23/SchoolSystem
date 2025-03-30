using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class LocalizenameofEntitiesintoaren : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubjectsId",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectsId",
                table: "InstructorSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectsId",
                table: "StudentSubjects");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Subjects",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "StudentSubjects",
                newName: "SubjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjects_SubjectsId",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_SubjectId1");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Students",
                newName: "NameAr");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "InstructorSubject",
                newName: "SubjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSubject_SubjectsId",
                table: "InstructorSubject",
                newName: "IX_InstructorSubject_SubjectId1");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Instructor",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "SubjectsId",
                table: "DepartmentSubjects",
                newName: "SubjectId1");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentSubjects_SubjectsId",
                table: "DepartmentSubjects",
                newName: "IX_DepartmentSubjects_SubjectId1");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Departments",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "Students",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Instructor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Departments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubjectId1",
                table: "DepartmentSubjects",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectId1",
                table: "InstructorSubject",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId1",
                table: "StudentSubjects",
                column: "SubjectId1",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubjectId1",
                table: "DepartmentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectId1",
                table: "InstructorSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectId1",
                table: "StudentSubjects");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Departments");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Subjects",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SubjectId1",
                table: "StudentSubjects",
                newName: "SubjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubjects_SubjectId1",
                table: "StudentSubjects",
                newName: "IX_StudentSubjects_SubjectsId");

            migrationBuilder.RenameColumn(
                name: "NameAr",
                table: "Students",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SubjectId1",
                table: "InstructorSubject",
                newName: "SubjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_InstructorSubject_SubjectId1",
                table: "InstructorSubject",
                newName: "IX_InstructorSubject_SubjectsId");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Instructor",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SubjectId1",
                table: "DepartmentSubjects",
                newName: "SubjectsId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentSubjects_SubjectId1",
                table: "DepartmentSubjects",
                newName: "IX_DepartmentSubjects_SubjectsId");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Departments",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubjectsId",
                table: "DepartmentSubjects",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InstructorSubject_Subjects_SubjectsId",
                table: "InstructorSubject",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubjects_Subjects_SubjectsId",
                table: "StudentSubjects",
                column: "SubjectsId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }
    }
}
