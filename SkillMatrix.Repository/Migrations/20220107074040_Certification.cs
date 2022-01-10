using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillMatrix.Repository.Migrations
{
    public partial class Certification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Certification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgentName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OSVC_Score = table.Column<double>(type: "double", nullable: true),
                    OA_Score = table.Column<double>(type: "double", nullable: true),
                    EM_Score = table.Column<double>(type: "double", nullable: true),
                    EarnedScore = table.Column<double>(type: "double", nullable: false),
                    TotalScore = table.Column<double>(type: "double", nullable: false),
                    CertificationDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certification", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LowerScore", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), 0, new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certification");

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LowerScore", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), 6, new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 12, 24, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
