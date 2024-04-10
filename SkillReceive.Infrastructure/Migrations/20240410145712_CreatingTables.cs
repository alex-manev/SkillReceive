using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillReceive.Infrastructure.Migrations
{
    public partial class CreatingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Creators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Creator identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Creator phone number"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnHandExperienceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "OnHandExperience category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Online course category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnHandExperienceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineCourseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Online course category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Online course category name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineCourseCategories", x => x.Id);
                },
                comment: "Online course category");

            migrationBuilder.CreateTable(
                name: "OnHandExperiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "On Hand Experience identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "On Hand Experience title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "On Hand Experience description"),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "On Hand Experience location"),
                    Requirements = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "On Hand Experience location"),
                    PricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Monthly price"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "On Hand Experience image url"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    CreatorId = table.Column<int>(type: "int", nullable: false, comment: "On Hand Experience creator identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnHandExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnHandExperiences_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnHandExperiences_OnHandExperienceCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "OnHandExperienceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "On Hand Experience");

            migrationBuilder.CreateTable(
                name: "OnlineCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Online course identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Online course title"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Online course description"),
                    NeededTechnologies = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "Online course description"),
                    PricePerMonth = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Monthly price"),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Online course image url"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    CreatorId = table.Column<int>(type: "int", nullable: false, comment: "Online course creator identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineCourses_Creators_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Creators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineCourses_OnlineCourseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "OnlineCourseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Online Course");

            migrationBuilder.CreateIndex(
                name: "IX_Creators_UserId",
                table: "Creators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OnHandExperiences_CategoryId",
                table: "OnHandExperiences",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnHandExperiences_CreatorId",
                table: "OnHandExperiences",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineCourses_CategoryId",
                table: "OnlineCourses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineCourses_CreatorId",
                table: "OnlineCourses",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnHandExperiences");

            migrationBuilder.DropTable(
                name: "OnlineCourses");

            migrationBuilder.DropTable(
                name: "OnHandExperienceCategories");

            migrationBuilder.DropTable(
                name: "Creators");

            migrationBuilder.DropTable(
                name: "OnlineCourseCategories");
        }
    }
}
