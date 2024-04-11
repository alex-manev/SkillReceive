using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillReceive.Infrastructure.Migrations
{
    public partial class UniqueConstraintForPhoneNumberAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "Creators",
                comment: "Skill Creator");

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
                name: "IX_Creators_PhoneNumber",
                table: "Creators",
                column: "PhoneNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Creators_PhoneNumber",
                table: "Creators");

            migrationBuilder.AlterTable(
                name: "Creators",
                oldComment: "Skill Creator");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02303387-44fb-479b-859d-001bb0a0cc96", "AQAAAAEAACcQAAAAEPlSVXevfr1HLEjcgzbJLTs+CsbVbQPAcnZnEyNy9z6aiB+T1pl8vlzYAtf4APS9Mg==", "9b24b725-e891-45f0-b188-5b0a81aa6716" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3203b420-8e27-4ef3-b4d2-7316ecd1da2e", "AQAAAAEAACcQAAAAEBdzuE6KRVe4B8RGGjNZOZt1Dzse89YP+T9Y7LuIGPFfftvTvbUUfQ6RV8FWqskRjA==", "7408d991-2d77-4d6b-90a6-7210eebb542b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a85e1a40-1152-4c9b-ae0b-3abea7506e05", "AQAAAAEAACcQAAAAECCCIpHtMvZ4sSu9cpbjsHDzYhRQFhws08nKSJOLtnoF+VPVtSHMK3d7uhn57b8Ngw==", "c7535c7f-28fd-4ce2-8493-575b51d2c33e" });
        }
    }
}
