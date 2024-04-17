using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillReceive.Infrastructure.Migrations
{
    public partial class AdminAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d7a10ea-d9d0-4ec5-8924-d008ca3a3325", "Real", "Life", "AQAAAAEAACcQAAAAEHnR/aqYZvg9jPO4hdyajjlKjQkjL8bPGhoTfXICPWN58Tb4kVhyekwx5AE0Y8VGiA==", "1e802634-c243-4509-bc36-47d76b25e1fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62d0f90d-3d72-473c-b3a2-a0170d07e965", "Online", "User", "AQAAAAEAACcQAAAAEJAGe9GyY0WUg+dB55SNwaHqFrcT2QuIVZ96sTBn+gvaX9aImUgcs7l/1hIIpGtzQA==", "4cb287e9-18a7-4779-bf4b-68e7c634d13b" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df83445d-7e23-4fea-a2c5-5cd1232083c4", 0, "85e49973-63ad-460b-9107-ae0adaca0f11", "admin@mail.com", false, "Great", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEE2nn6yoqOR21kSHV99FC7l+ullT2ax2Ar5y5yKisVVMEm17zUaAjTTh+sGBRx04rw==", null, false, "f735978f-d80d-4b46-a807-467f93104518", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Creators",
                columns: new[] { "Id", "PhoneNumber", "UserId" },
                values: new object[] { 4, "08934257381", "df83445d-7e23-4fea-a2c5-5cd1232083c4" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Creators",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df83445d-7e23-4fea-a2c5-5cd1232083c4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "839a8755-e35f-4693-910e-3df0ad03fac9", "", "", "AQAAAAEAACcQAAAAEOk9Dy1nAC77YLAdh84QHGeppoOL+8ToKJZJq0UTEfM50T2kE8OdA+0vDVAewlbt3w==", "39671589-ff6f-4c8c-9eeb-41b11ffdcf0c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4c170cb-06f0-408f-9cc5-287e661809b5", "", "", "AQAAAAEAACcQAAAAEMPr+SXpCNEEuzM2KhtwlccsJpiMeybPjqqtzAU7qZVg/ogvdKRAoOOYzStQQPBzqA==", "e0ef128e-f0b4-4d5d-a9fa-8746e86994a3" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "499d7b45-13ee-4817-b957-2ad1ef6bb407", "guest@mail.com", false, "", "", false, null, "guest@mail.com", "guest@mail.com", "AQAAAAEAACcQAAAAEJgN1X9p2V+BiJ5wLuVU4wYEY8Jmq9EZB/fJJ7/oPtxguJ1vKRbZnJcc8BmH57mXlQ==", null, false, "5788fe88-c210-4311-a418-e819220bf9ba", false, "guest@mail.com" });
        }
    }
}
