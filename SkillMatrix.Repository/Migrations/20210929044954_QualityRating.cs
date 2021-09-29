using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SkillMatrix.Repository.Migrations
{
    public partial class QualityRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityRating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Department = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    AgentName = table.Column<string>(type: "text", nullable: true),
                    EmployeeId = table.Column<string>(type: "text", nullable: true),
                    TaskCompletionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    QADate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: true),
                    TicketNumber = table.Column<string>(type: "text", nullable: true),
                    TicketStatus = table.Column<string>(type: "text", nullable: true),
                    RequestReason = table.Column<string>(type: "text", nullable: true),
                    CustomerType = table.Column<string>(type: "text", nullable: true),
                    ProcessAdheranceScore = table.Column<double>(type: "double", nullable: false),
                    EmailHandlingScore = table.Column<double>(type: "double", nullable: false),
                    ResolutionScore = table.Column<double>(type: "double", nullable: false),
                    ToneScore = table.Column<double>(type: "double", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    TotalScore = table.Column<double>(type: "double", nullable: false),
                    StraiveTotalScore = table.Column<double>(type: "double", nullable: false),
                    QTPName = table.Column<string>(type: "text", nullable: true),
                    QTPEmployeeId = table.Column<string>(type: "text", nullable: true),
                    Variance = table.Column<double>(type: "double", nullable: false),
                    OverallExperience = table.Column<string>(type: "text", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRating", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 9, 29, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityRating");

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
