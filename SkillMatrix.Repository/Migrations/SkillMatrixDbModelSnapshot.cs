﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillMatrix.Repository;

namespace SkillMatrix.Repository.Migrations
{
    [DbContext(typeof(SkillMatrixDb))]
    partial class SkillMatrixDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("SkillMatrix.Model.CategoryScoring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("LowerScore")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("double");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UpperScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CategoryScoring");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 0,
                            Score = 0.0,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 1,
                            Score = 1.0,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 85
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 85,
                            Score = 2.0,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 92
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 92,
                            Score = 3.0,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 94
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 94,
                            Score = 4.0,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 99
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 99,
                            Score = 5.0,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 10000
                        });
                });

            modelBuilder.Entity("SkillMatrix.Model.CompetencyLevelScoring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Level")
                        .HasColumnType("text");

                    b.Property<double>("LowerScore")
                        .HasColumnType("double");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<double>("UpperScore")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("CompetencyLevelScoring");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Novice",
                            LowerScore = 0.0,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 2.4900000000000002
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Advanced Beginner",
                            LowerScore = 2.5,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 3.4900000000000002
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Competent",
                            LowerScore = 3.5,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 3.9900000000000002
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Proficient",
                            LowerScore = 4.0,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 4.4900000000000002
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Expert",
                            LowerScore = 4.5,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 5.0
                        });
                });

            modelBuilder.Entity("SkillMatrix.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateHired")
                        .HasColumnType("datetime");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("SkillMatrix.Model.EmployeeSkillMatrix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("AvgQuestionsStatisticsReport")
                        .HasColumnType("double");

                    b.Property<string>("CSATLevel")
                        .HasColumnType("text");

                    b.Property<double>("CSATScore")
                        .HasColumnType("double");

                    b.Property<string>("CertificationLevel")
                        .HasColumnType("text");

                    b.Property<double>("CertificationScore")
                        .HasColumnType("double");

                    b.Property<string>("CompetencyLevel")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("DateHired")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("OverallScore")
                        .HasColumnType("double");

                    b.Property<double>("ProcessSpecific_PR")
                        .HasColumnType("double")
                        .HasColumnName("ProficiencyReportProcessSpecific");

                    b.Property<double>("ProcessSpecific_QSR")
                        .HasColumnType("double")
                        .HasColumnName("QuestionsStatisticsReportProcessSpecific");

                    b.Property<string>("ProcessSpecific_TS")
                        .HasColumnType("text")
                        .HasColumnName("TimeSpentProcessSpecific");

                    b.Property<string>("QCLevel")
                        .HasColumnType("text");

                    b.Property<double>("QCScore")
                        .HasColumnType("double");

                    b.Property<int>("Quarter")
                        .HasColumnType("int");

                    b.Property<int>("ScoreCount")
                        .HasColumnType("int");

                    b.Property<double>("ScoreSum")
                        .HasColumnType("double");

                    b.Property<double>("StarAndOSvC_PR")
                        .HasColumnType("double")
                        .HasColumnName("ProficiencyReportStarAndOSvC");

                    b.Property<double>("StarAndOSvC_QSR")
                        .HasColumnType("double")
                        .HasColumnName("QuestionsStatisticsReportStarAndOSvC");

                    b.Property<string>("StarAndOSvC_TS")
                        .HasColumnType("text")
                        .HasColumnName("TimeSpentStarAndOSvC");

                    b.Property<string>("Team")
                        .HasColumnType("text");

                    b.Property<string>("TenureLevel")
                        .HasColumnType("text");

                    b.Property<int>("TenureMonths")
                        .HasColumnType("int");

                    b.Property<string>("TenurePlusCompetency")
                        .HasColumnType("text");

                    b.Property<int>("TenureYears")
                        .HasColumnType("int");

                    b.Property<string>("TotalTimeSpent")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EmployeeSkillMatrix");
                });

            modelBuilder.Entity("SkillMatrix.Model.TenureLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Level")
                        .HasColumnType("text");

                    b.Property<int>("LowerScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime");

                    b.Property<int>("UpperScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TenureLevel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Novice",
                            LowerScore = 6,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 9
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Advanced Beginner",
                            LowerScore = 10,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 12
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Competent",
                            LowerScore = 13,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 1000
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Proficient",
                            LowerScore = 13,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 1000
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Expert",
                            LowerScore = 13,
                            UpdatedDate = new DateTime(2021, 8, 24, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 1000
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
