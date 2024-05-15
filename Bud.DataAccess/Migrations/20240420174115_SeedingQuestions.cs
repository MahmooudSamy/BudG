using Microsoft.EntityFrameworkCore.Migrations;

namespace BudG.DataAccess.Migrations
{
    public partial class SeedingQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuesId", "QuestionShape" },
                values: new object[,]
                {
                    { -1, "What was the name of your first school teacher?" },
                    { -2, "What year did you enter college?" },
                    { -3, "What is your grandmother’s maiden name?" },
                    { -4, "How old are you?" },
                    { -5, "What is your child’s nickname?" },
                    { -6, "What is the manufacturer of your first car?" },
                    { -7, "What was the name of your favorite childhood pet?" },
                    { -8, "What is your favorite sport?" },
                    { -9, "In which area of the city is your place of work located?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuesId",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuesId",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuesId",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuesId",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuesId",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuesId",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuesId",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuesId",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuesId",
                keyValue: -1);
        }
    }
}
