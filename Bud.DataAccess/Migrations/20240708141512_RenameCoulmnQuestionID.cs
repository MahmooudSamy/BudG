using Microsoft.EntityFrameworkCore.Migrations;

namespace BudG.DataAccess.Migrations
{
    public partial class RenameCoulmnQuestionID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
              name: "FK_Answers_Questions_QuesId",
              table: "Answers",
              column: "QuesId",
              principalTable: "Questions",
              principalColumn: "QuesId",
              onDelete: ReferentialAction.Cascade);

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuesId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuesId",
                table: "Questions",
                newName: "QuestionId");

            migrationBuilder.RenameColumn(
                name: "QuesId",
                table: "Answers",
                newName: "QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuesId",
                table: "Answers",
                newName: "IX_Answers_QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionId",
                table: "Answers");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Questions",
                newName: "QuesId");

            migrationBuilder.RenameColumn(
                name: "QuestionId",
                table: "Answers",
                newName: "QuesId");

            migrationBuilder.RenameIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                newName: "IX_Answers_QuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuesId",
                table: "Answers",
                column: "QuesId",
                principalTable: "Questions",
                principalColumn: "QuesId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
