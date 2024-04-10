using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillReceive.Infrastructure.Migrations
{
    public partial class DataSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OnHandExperienceId", "OnlineCourseId", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "02303387-44fb-479b-859d-001bb0a0cc96", "realLife@mail.com", false, false, null, "realLife@mail.com", "realLife@mail.com", null, null, "AQAAAAEAACcQAAAAEPlSVXevfr1HLEjcgzbJLTs+CsbVbQPAcnZnEyNy9z6aiB+T1pl8vlzYAtf4APS9Mg==", null, false, "9b24b725-e891-45f0-b188-5b0a81aa6716", false, "realLife@mail.com" },
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "3203b420-8e27-4ef3-b4d2-7316ecd1da2e", "guest@mail.com", false, false, null, "guest@mail.com", "guest@mail.com", null, null, "AQAAAAEAACcQAAAAEBdzuE6KRVe4B8RGGjNZOZt1Dzse89YP+T9Y7LuIGPFfftvTvbUUfQ6RV8FWqskRjA==", null, false, "7408d991-2d77-4d6b-90a6-7210eebb542b", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "a85e1a40-1152-4c9b-ae0b-3abea7506e05", "onlineUser@mail.com", false, false, null, "onlineUser@mail.com", "onlineUser@mail.com", null, null, "AQAAAAEAACcQAAAAECCCIpHtMvZ4sSu9cpbjsHDzYhRQFhws08nKSJOLtnoF+VPVtSHMK3d7uhn57b8Ngw==", null, false, "c7535c7f-28fd-4ce2-8493-575b51d2c33e", false, "onlineUser@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "OnHandExperienceCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sports" },
                    { 2, "Culinary" },
                    { 3, "Manual Labor" }
                });

            migrationBuilder.InsertData(
                table: "OnlineCourseCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Business & Management" },
                    { 2, "Design & Arts" },
                    { 3, "Programming" }
                });

            migrationBuilder.InsertData(
                table: "Creators",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 1, "1234567890", "dea12856-c198-4129-b3f3-b893d8395082" });

            migrationBuilder.InsertData(
                table: "Creators",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 2, "4214267391", "02174cf0–9412–4cfe-afbf-59f706d72cf6" });

            migrationBuilder.InsertData(
                table: "OnHandExperiences",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Description", "ImageURL", "Location", "PricePerMonth", "Requirements", "Title" },
                values: new object[] { 1, 1, 2, "Dive into the exhilarating world of volleyball with our comprehensive Volleyball Fundamentals tutorial. Geared towards beginners, this guide offers a solid foundation in the essential skills and techniques needed to excel in this fast-paced sport. Whether you're stepping onto the court for the first time or looking to refine your game, this tutorial is your ultimate resource.", "https://media.istockphoto.com/id/1305166860/vector/volleyball-sports-glyph-icon.jpg?s=612x612&w=0&k=20&c=t67-m41qaiSnaOuWjLtkytN1RAqAiiXc9QmLu68fTS8=", "123 St.Main Street 2700", 15.00m, "Height: at least 180cm, Weight: at least 75kg, Age: Must be 18 or older", "Volleyball Fundamentals: Mastering the Basics of the Game" });

            migrationBuilder.InsertData(
                table: "OnlineCourses",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Description", "ImageURL", "NeededTechnologies", "PricePerMonth", "Title" },
                values: new object[] { 1, 3, 1, "Learn the essential syntax of JavaScript, including variables, data types, operators, and control flow structures. Dive into functions and explore how they enable you to write reusable and modular code. Understand the power of JavaScript objects and arrays for organizing and manipulating data. Discover how to interact with HTML elements and dynamically update web pages using JavaScript.", "https://www.tutorialrepublic.com/lib/images/javascript-illustration.png", "VisualStudio/VisualStudio Code, Microsoft Teams, GitHub", 10.00m, "JavaScript Basics: A Beginner's Guide" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "OnHandExperienceCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OnHandExperienceCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OnHandExperiences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OnlineCourseCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OnlineCourseCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OnlineCourses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Creators",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Creators",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OnHandExperienceCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OnlineCourseCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");
        }
    }
}
