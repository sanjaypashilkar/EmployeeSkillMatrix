using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SkillMatrix.Repository.Migrations
{
    public partial class SkillMatrix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryScoring",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LowerScore = table.Column<int>(type: "int", nullable: false),
                    UpperScore = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<double>(type: "double", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryScoring", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompetencyLevelScoring",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LowerScore = table.Column<double>(type: "double", nullable: false),
                    UpperScore = table.Column<double>(type: "double", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetencyLevelScoring", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DateHired = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkillMatrix",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Quarter = table.Column<int>(type: "int", nullable: false),
                    Team = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    DateHired = table.Column<DateTime>(type: "datetime", nullable: false),
                    TenureYears = table.Column<int>(type: "int", nullable: false),
                    TenureMonths = table.Column<int>(type: "int", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProficiencyReportProcessSpecific = table.Column<double>(type: "double", nullable: false),
                    ProficiencyReportStarAndOSvC = table.Column<double>(type: "double", nullable: false),
                    TimeSpentProcessSpecific = table.Column<string>(type: "text", nullable: true),
                    TimeSpentStarAndOSvC = table.Column<string>(type: "text", nullable: true),
                    TotalTimeSpent = table.Column<string>(type: "text", nullable: true),
                    QuestionsStatisticsReportProcessSpecific = table.Column<double>(type: "double", nullable: false),
                    QuestionsStatisticsReportStarAndOSvC = table.Column<double>(type: "double", nullable: false),
                    AvgQuestionsStatisticsReport = table.Column<double>(type: "double", nullable: false),
                    CertificationScore = table.Column<double>(type: "double", nullable: false),
                    CertificationLevel = table.Column<string>(type: "text", nullable: true),
                    CSATScore = table.Column<double>(type: "double", nullable: false),
                    CSATLevel = table.Column<string>(type: "text", nullable: true),
                    QCScore = table.Column<double>(type: "double", nullable: false),
                    QCLevel = table.Column<string>(type: "text", nullable: true),
                    ScoreSum = table.Column<double>(type: "double", nullable: false),
                    ScoreCount = table.Column<int>(type: "int", nullable: false),
                    OverallScore = table.Column<double>(type: "double", nullable: false),
                    CompetencyLevel = table.Column<string>(type: "text", nullable: true),
                    TenureLevel = table.Column<string>(type: "text", nullable: true),
                    TenurePlusCompetency = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkillMatrix", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenureLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LowerScore = table.Column<int>(type: "int", nullable: false),
                    UpperScore = table.Column<int>(type: "int", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenureLevel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CategoryScoring",
                columns: new[] { "Id", "CreatedDate", "LowerScore", "Score", "UpdatedDate", "UpperScore" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 0, 1.0, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 85 },
                    { 2, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 85, 2.0, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 92 },
                    { 3, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 92, 3.0, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 94 },
                    { 4, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 94, 4.0, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 99 },
                    { 5, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 99, 5.0, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 10000 }
                });

            migrationBuilder.InsertData(
                table: "CompetencyLevelScoring",
                columns: new[] { "Id", "CreatedDate", "Level", "LowerScore", "UpdatedDate", "UpperScore" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Novice", 0.0, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 2.4900000000000002 },
                    { 2, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Advanced Beginner", 2.5, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 3.4900000000000002 },
                    { 3, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Competent", 3.5, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 3.9900000000000002 },
                    { 4, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Proficient", 4.0, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 4.4900000000000002 },
                    { 5, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Expert", 4.5, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 5.0 }
                });

            migrationBuilder.InsertData(
                table: "TenureLevel",
                columns: new[] { "Id", "CreatedDate", "Level", "LowerScore", "UpdatedDate", "UpperScore" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Beginner", 6, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 9 },
                    { 2, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Novice", 10, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 12 },
                    { 3, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "Advanced", 13, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 1000 },
                    { 4, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), "SME", 13, new DateTime(2021, 8, 11, 0, 0, 0, 0, DateTimeKind.Local), 1000 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryScoring");

            migrationBuilder.DropTable(
                name: "CompetencyLevelScoring");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeSkillMatrix");

            migrationBuilder.DropTable(
                name: "TenureLevel");
        }
    }
}
