using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillReceive.Infrastructure.Migrations
{
    public partial class DeleteBehaviorChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnHandExperiences_Creators_CreatorId",
                table: "OnHandExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_OnHandExperiences_OnHandExperienceCategories_CategoryId",
                table: "OnHandExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineCourses_Creators_CreatorId",
                table: "OnlineCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineCourses_OnlineCourseCategories_CategoryId",
                table: "OnlineCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_OnHandExperiences_Creators_CreatorId",
                table: "OnHandExperiences",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnHandExperiences_OnHandExperienceCategories_CategoryId",
                table: "OnHandExperiences",
                column: "CategoryId",
                principalTable: "OnHandExperienceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineCourses_Creators_CreatorId",
                table: "OnlineCourses",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineCourses_OnlineCourseCategories_CategoryId",
                table: "OnlineCourses",
                column: "CategoryId",
                principalTable: "OnlineCourseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnHandExperiences_Creators_CreatorId",
                table: "OnHandExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_OnHandExperiences_OnHandExperienceCategories_CategoryId",
                table: "OnHandExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineCourses_Creators_CreatorId",
                table: "OnlineCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_OnlineCourses_OnlineCourseCategories_CategoryId",
                table: "OnlineCourses");

            migrationBuilder.AddForeignKey(
                name: "FK_OnHandExperiences_Creators_CreatorId",
                table: "OnHandExperiences",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnHandExperiences_OnHandExperienceCategories_CategoryId",
                table: "OnHandExperiences",
                column: "CategoryId",
                principalTable: "OnHandExperienceCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineCourses_Creators_CreatorId",
                table: "OnlineCourses",
                column: "CreatorId",
                principalTable: "Creators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OnlineCourses_OnlineCourseCategories_CategoryId",
                table: "OnlineCourses",
                column: "CategoryId",
                principalTable: "OnlineCourseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
