using Microsoft.EntityFrameworkCore.Migrations;

namespace BudG.DataAccess.Migrations
{
    public partial class EditOnMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionQuesId",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionQuesId",
                table: "Answers",
                column: "QuestionQuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionQuesId",
                table: "Answers",
                column: "QuestionQuesId",
                principalTable: "Questions",
                principalColumn: "QuesId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.DropForeignKey(
                name: "FK_Answers_Questions_QuestionQuesId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_QuestionQuesId",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "QuestionQuesId",
                table: "Answers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionQuesId",
                table: "Answers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionQuesId",
                table: "Answers",
                column: "QuestionQuesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_Questions_QuestionQuesId",
                table: "Answers",
                column: "QuestionQuesId",
                principalTable: "Questions",
                principalColumn: "QuesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
