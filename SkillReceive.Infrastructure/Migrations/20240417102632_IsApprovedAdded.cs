using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillReceive.Infrastructure.Migrations
{
    public partial class IsApprovedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "OnlineCourses",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is skill approved by admin");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "OnHandExperiences",
                type: "bit",
                nullable: false,
                defaultValue: false,
                comment: "Is skill approved by admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ec5ac99-291a-4e3b-846d-564573daac78", "AQAAAAEAACcQAAAAEA7+murzk0W5ynAdG/GkZnBJOvCXv1EThq3wnG5auaMaKMoxNxDCFUdz8rDeAYuNOg==", "a8c5ab9b-77d0-49fc-a84c-8e678fd4c518" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a91f5171-57cf-40cb-b3e8-bde50b2c712b", "AQAAAAEAACcQAAAAEMWhlgXXZk5MumzhTLXha6gsXjUaBtVIRs8V6jX0zrqeFjPvQLO/BPRF89zOm3qViA==", "cc583172-e0b8-452f-8f34-e19c0ab09569" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df83445d-7e23-4fea-a2c5-5cd1232083c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "830d4eba-dcd6-4a57-989f-1de395c53864", "AQAAAAEAACcQAAAAEGYUesoHKRYWv96aB54KzqZRC7mp60UYNK8MHPifxidQ9qfGEMMPnCeVN1ySU/vT5g==", "00c66291-f9e5-45ef-8812-7c36ad775961" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "OnlineCourses");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "OnHandExperiences");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02174cf0–9412–4cfe-afbf-59f706d72cf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d7a10ea-d9d0-4ec5-8924-d008ca3a3325", "AQAAAAEAACcQAAAAEHnR/aqYZvg9jPO4hdyajjlKjQkjL8bPGhoTfXICPWN58Tb4kVhyekwx5AE0Y8VGiA==", "1e802634-c243-4509-bc36-47d76b25e1fa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62d0f90d-3d72-473c-b3a2-a0170d07e965", "AQAAAAEAACcQAAAAEJAGe9GyY0WUg+dB55SNwaHqFrcT2QuIVZ96sTBn+gvaX9aImUgcs7l/1hIIpGtzQA==", "4cb287e9-18a7-4779-bf4b-68e7c634d13b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df83445d-7e23-4fea-a2c5-5cd1232083c4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85e49973-63ad-460b-9107-ae0adaca0f11", "AQAAAAEAACcQAAAAEE2nn6yoqOR21kSHV99FC7l+ullT2ax2Ar5y5yKisVVMEm17zUaAjTTh+sGBRx04rw==", "f735978f-d80d-4b46-a807-467f93104518" });
        }
    }
}
