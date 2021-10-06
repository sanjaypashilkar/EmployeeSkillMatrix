using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SkillMatrix.Repository.Migrations
{
    public partial class QualityRating2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualityRating2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Department = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EmployeeId = table.Column<string>(type: "text", nullable: true),
                    Group = table.Column<string>(type: "text", nullable: true),
                    TeamLeader = table.Column<string>(type: "text", nullable: true),
                    TaskCompletionDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    AuditedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Process = table.Column<string>(type: "text", nullable: true),
                    ErrorType = table.Column<string>(type: "text", nullable: true),
                    CheckerRemarks = table.Column<string>(type: "text", nullable: true),
                    Modified = table.Column<string>(type: "text", nullable: true),
                    TicketNumber = table.Column<string>(type: "text", nullable: true),
                    Shift = table.Column<string>(type: "text", nullable: true),
                    Lines = table.Column<int>(type: "int", nullable: false),
                    IssueType = table.Column<string>(type: "text", nullable: true),
                    TLAnalysis = table.Column<string>(type: "text", nullable: true),
                    Level1Opportunity = table.Column<string>(type: "text", nullable: true),
                    Level2Opportunity = table.Column<string>(type: "text", nullable: true),
                    RootCause = table.Column<string>(type: "text", nullable: true),
                    CorrectiveAction = table.Column<string>(type: "text", nullable: true),
                    PreventiveAction = table.Column<string>(type: "text", nullable: true),
                    ProcessChange = table.Column<string>(type: "text", nullable: true),
                    EffectivenessVerification = table.Column<string>(type: "text", nullable: true),
                    AuditResult = table.Column<string>(type: "text", nullable: true),
                    DOIVerification = table.Column<string>(type: "text", nullable: true),
                    IsCorrect = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsError = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WeekRange = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Volume = table.Column<double>(type: "double", nullable: false),
                    Counter = table.Column<int>(type: "int", nullable: false),
                    EmpIdDate = table.Column<string>(type: "text", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRating2", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CategoryScoring",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "CompetencyLevelScoring",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TenureLevel",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Local) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualityRating2");

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
    }
}
