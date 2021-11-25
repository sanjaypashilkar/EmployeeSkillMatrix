using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillMatrix.Repository.Migrations
{
    public partial class Elsevier_Quality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityRating3",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AccountType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Month = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TeamLead = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AgentName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmployeeId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CF1_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    CF1_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    CF2_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    CF2_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    CF3_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    CF3_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    CF4_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    CF4_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    SF1_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    SF1_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    SF2_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    SF2_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    SF3_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    SF3_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    BP1_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    BP1_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    BP2_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    BP2_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    BP3_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    BP3_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    IC1_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    IC1_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    IC2_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    IC2_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    IC3_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    IC3_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    IC4_PointsEarned = table.Column<int>(type: "int", nullable: false),
                    IC4_TotalPoints = table.Column<int>(type: "int", nullable: false),
                    PassiveSurvey = table.Column<double>(type: "double", nullable: false),
                    CSATScore = table.Column<double>(type: "double", nullable: false),
                    NoOfPplOpportunity = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RecordDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRating3", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 24, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityRating3");

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 11, 23, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
