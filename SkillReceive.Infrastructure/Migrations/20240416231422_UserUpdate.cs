using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillReceive.Infrastructure.Migrations
{
    public partial class UserUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_OnHandExperiences_OnHandExperienceId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_OnlineCourses_OnlineCourseId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OnHandExperienceId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_OnlineCourseId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OnHandExperienceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OnlineCourseId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ApplicationUserOnHandExperience",
                columns: table => new
                {
                    OnHandExperiencesId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserOnHandExperience", x => new { x.OnHandExperiencesId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserOnHandExperience_AspNetUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserOnHandExperience_OnHandExperiences_OnHandExperiencesId",
                        column: x => x.OnHandExperiencesId,
                        principalTable: "OnHandExperiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserOnlineCourse",
                columns: table => new
                {
                    OnlineCoursesId = table.Column<int>(type: "int", nullable: false),
                    ParticipantsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserOnlineCourse", x => new { x.OnlineCoursesId, x.ParticipantsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserOnlineCourse_AspNetUsers_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserOnlineCourse_OnlineCourses_OnlineCoursesId",
                        column: x => x.OnlineCoursesId,
                        principalTable: "OnlineCourses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "839a8755-e35f-4693-910e-3df0ad03fac9", "", "", "AQAAAAEAACcQAAAAEOk9Dy1nAC77YLAdh84QHGeppoOL+8ToKJZJq0UTEfM50T2kE8OdA+0vDVAewlbt3w==", "39671589-ff6f-4c8c-9eeb-41b11ffdcf0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "499d7b45-13ee-4817-b957-2ad1ef6bb407", "", "", "AQAAAAEAACcQAAAAEJgN1X9p2V+BiJ5wLuVU4wYEY8Jmq9EZB/fJJ7/oPtxguJ1vKRbZnJcc8BmH57mXlQ==", "5788fe88-c210-4311-a418-e819220bf9ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4c170cb-06f0-408f-9cc5-287e661809b5", "", "", "AQAAAAEAACcQAAAAEMPr+SXpCNEEuzM2KhtwlccsJpiMeybPjqqtzAU7qZVg/ogvdKRAoOOYzStQQPBzqA==", "e0ef128e-f0b4-4d5d-a9fa-8746e86994a3" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserOnHandExperience_ParticipantsId",
                table: "ApplicationUserOnHandExperience",
                column: "ParticipantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserOnlineCourse_ParticipantsId",
                table: "ApplicationUserOnlineCourse",
                column: "ParticipantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserOnHandExperience");

            migrationBuilder.DropTable(
                name: "ApplicationUserOnlineCourse");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "OnHandExperienceId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnlineCourseId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84147f01-7f9e-42be-b5bc-d1a8afda0adc", "AQAAAAEAACcQAAAAEMZxTEB0KZ45EXNMcAuERrNqpSYuQSqtnHm1aSLM97XYnUFemzsVJKmw1Qfhx0ITsw==", "3bc300c2-73a1-4a2a-bcfd-1e4973cd5a4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af804f41-a92b-43ac-a72c-1f9d07c19bc2", "AQAAAAEAACcQAAAAEN6GPnZxr2C0OxOw5BcY1pr1KJfolgVdmlPDJzVHye2v2reobGyU/U3cxnZL6fkaGw==", "6553d2d6-5049-4eed-92f6-ac1bae2a4f95" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e0eb7b9-cb75-46db-85c8-36d16ce6f113", "AQAAAAEAACcQAAAAEEs29GYFmwRqHI55la159u38pfkP0PsoDIMckXOc9MU6FRv9UYdCQia2phMXOsq20Q==", "b52a8b8e-7bf7-4dcb-81b3-c6b4edb5b061" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OnHandExperienceId",
                table: "AspNetUsers",
                column: "OnHandExperienceId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_OnlineCourseId",
                table: "AspNetUsers",
                column: "OnlineCourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_OnHandExperiences_OnHandExperienceId",
                table: "AspNetUsers",
                column: "OnHandExperienceId",
                principalTable: "OnHandExperiences",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_OnlineCourses_OnlineCourseId",
                table: "AspNetUsers",
                column: "OnlineCourseId",
                principalTable: "OnlineCourses",
                principalColumn: "Id");
        }
    }
}
