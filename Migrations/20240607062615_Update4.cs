using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arq_backend.Migrations
{
    /// <inheritdoc />
    public partial class Update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Subjects_SubjectId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "DocumentPath",
                table: "Materials");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Materials",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Subjects_SubjectId",
                table: "Materials",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_Subjects_SubjectId",
                table: "Materials");

            migrationBuilder.AlterColumn<int>(
                name: "SubjectId",
                table: "Materials",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DocumentPath",
                table: "Materials",
                type: "TEXT",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_Subjects_SubjectId",
                table: "Materials",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
