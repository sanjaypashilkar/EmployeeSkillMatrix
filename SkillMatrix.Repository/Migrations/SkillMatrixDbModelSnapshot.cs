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
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("SkillMatrix.Model.BusinessPartner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<double>("BusinessPartnerNumber")
                        .HasColumnType("double");

                    b.Property<string>("ChangedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("ChangedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Comments")
                        .HasColumnType("longtext");

                    b.Property<string>("CountryKey")
                        .HasColumnType("longtext");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<string>("FirstName")
                        .HasColumnType("longtext");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("Institute1")
                        .HasColumnType("longtext");

                    b.Property<string>("Institute2")
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .HasColumnType("longtext");

                    b.Property<string>("Modified")
                        .HasColumnType("longtext");

                    b.Property<string>("Name1")
                        .HasColumnType("longtext");

                    b.Property<string>("Name2")
                        .HasColumnType("longtext");

                    b.Property<string>("Name3")
                        .HasColumnType("longtext");

                    b.Property<string>("POBox")
                        .HasColumnType("longtext");

                    b.Property<int>("PartnerCategory")
                        .HasColumnType("int");

                    b.Property<string>("PartnerType")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode1")
                        .HasColumnType("longtext");

                    b.Property<string>("PostalCode2")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Remarks")
                        .HasColumnType("longtext");

                    b.Property<string>("SalesOrganization1")
                        .HasColumnType("longtext");

                    b.Property<string>("SalesOrganization2")
                        .HasColumnType("longtext");

                    b.Property<string>("Street")
                        .HasColumnType("longtext");

                    b.Property<string>("TLRemarks")
                        .HasColumnType("longtext");

                    b.Property<string>("Team")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("Valid")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BusinessPartner");
                });

            modelBuilder.Entity("SkillMatrix.Model.CSAT", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<string>("AgentName")
                        .HasColumnType("longtext");

                    b.Property<double>("CSATScore")
                        .HasColumnType("double");

                    b.Property<double>("ComprNAccurate")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Effort")
                        .HasColumnType("double");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("longtext");

                    b.Property<double>("FTR")
                        .HasColumnType("double");

                    b.Property<string>("Month")
                        .HasColumnType("longtext");

                    b.Property<int>("NoOfRedFlags")
                        .HasColumnType("int");

                    b.Property<int>("NoOfSurveys")
                        .HasColumnType("int");

                    b.Property<double>("ProfessionalNHelpful")
                        .HasColumnType("double");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("Timely")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("CSAT");
                });

            modelBuilder.Entity("SkillMatrix.Model.CategoryScoring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("LowerScore")
                        .HasColumnType("int");

                    b.Property<double>("Score")
                        .HasColumnType("double");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpperScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CategoryScoring");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 0,
                            Score = 0.0,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 1,
                            Score = 1.0,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 85
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 85,
                            Score = 2.0,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 92
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 92,
                            Score = 3.0,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 94
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 94,
                            Score = 4.0,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 99
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            LowerScore = 99,
                            Score = 5.0,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 10000
                        });
                });

            modelBuilder.Entity("SkillMatrix.Model.Certification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<string>("AgentName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CertificationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double?>("EM_Score")
                        .HasColumnType("double");

                    b.Property<double>("EarnedScore")
                        .HasColumnType("double");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("longtext");

                    b.Property<double?>("OA_Score")
                        .HasColumnType("double");

                    b.Property<double?>("OSVC_Score")
                        .HasColumnType("double");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("TotalScore")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Certification");
                });

            modelBuilder.Entity("SkillMatrix.Model.CompetencyLevelScoring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Level")
                        .HasColumnType("longtext");

                    b.Property<double>("LowerScore")
                        .HasColumnType("double");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<double>("UpperScore")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("CompetencyLevelScoring");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Novice",
                            LowerScore = 0.0,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 2.4900000000000002
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Advanced Beginner",
                            LowerScore = 2.5,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 3.4900000000000002
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Competent",
                            LowerScore = 3.5,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 3.9900000000000002
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Proficient",
                            LowerScore = 4.0,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 4.4900000000000002
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Expert",
                            LowerScore = 4.5,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 5.0
                        });
                });

            modelBuilder.Entity("SkillMatrix.Model.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateHired")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Engagement")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("SAPUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("SPIEmployeeNo")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("SkillMatrix.Model.EmployeeSkillMatrix", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<double>("AvgQuestionsStatisticsReport")
                        .HasColumnType("double");

                    b.Property<string>("CSATLevel")
                        .HasColumnType("longtext");

                    b.Property<double>("CSATScore")
                        .HasColumnType("double");

                    b.Property<string>("CertificationLevel")
                        .HasColumnType("longtext");

                    b.Property<double>("CertificationScore")
                        .HasColumnType("double");

                    b.Property<string>("CompetencyLevel")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateCompleted")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateHired")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<double>("OverallScore")
                        .HasColumnType("double");

                    b.Property<double>("ProcessSpecific_PR")
                        .HasColumnType("double")
                        .HasColumnName("ProficiencyReportProcessSpecific");

                    b.Property<double>("ProcessSpecific_QSR")
                        .HasColumnType("double")
                        .HasColumnName("QuestionsStatisticsReportProcessSpecific");

                    b.Property<string>("ProcessSpecific_TS")
                        .HasColumnType("longtext")
                        .HasColumnName("TimeSpentProcessSpecific");

                    b.Property<string>("QCLevel")
                        .HasColumnType("longtext");

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
                        .HasColumnType("longtext")
                        .HasColumnName("TimeSpentStarAndOSvC");

                    b.Property<string>("Team")
                        .HasColumnType("longtext");

                    b.Property<string>("TenureLevel")
                        .HasColumnType("longtext");

                    b.Property<int>("TenureMonths")
                        .HasColumnType("int");

                    b.Property<string>("TenurePlusCompetency")
                        .HasColumnType("longtext");

                    b.Property<int>("TenureYears")
                        .HasColumnType("int");

                    b.Property<string>("TotalTimeSpent")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EmployeeSkillMatrix");
                });

            modelBuilder.Entity("SkillMatrix.Model.QualityRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<string>("AgentName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CustomerType")
                        .HasColumnType("longtext");

                    b.Property<string>("Department")
                        .HasColumnType("longtext");

                    b.Property<double>("EmailHandlingScore")
                        .HasColumnType("double");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("longtext");

                    b.Property<string>("OverallExperience")
                        .HasColumnType("longtext");

                    b.Property<double>("ProcessAdheranceScore")
                        .HasColumnType("double");

                    b.Property<DateTime>("QADate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("QTPEmployeeId")
                        .HasColumnType("longtext");

                    b.Property<string>("QTPName")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Region")
                        .HasColumnType("longtext");

                    b.Property<string>("Remarks")
                        .HasColumnType("longtext");

                    b.Property<string>("RequestReason")
                        .HasColumnType("longtext");

                    b.Property<double>("ResolutionScore")
                        .HasColumnType("double");

                    b.Property<double>("StraiveTotalScore")
                        .HasColumnType("double");

                    b.Property<DateTime>("TaskCompletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Team")
                        .HasColumnType("longtext");

                    b.Property<string>("TicketNumber")
                        .HasColumnType("longtext");

                    b.Property<string>("TicketStatus")
                        .HasColumnType("longtext");

                    b.Property<double>("ToneScore")
                        .HasColumnType("double");

                    b.Property<double>("TotalScore")
                        .HasColumnType("double");

                    b.Property<double>("Variance")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("QualityRating");
                });

            modelBuilder.Entity("SkillMatrix.Model.QualityRating2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<string>("AuditResult")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("AuditedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CheckerRemarks")
                        .HasColumnType("longtext");

                    b.Property<string>("CorrectiveAction")
                        .HasColumnType("longtext");

                    b.Property<int>("Counter")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DOIVerification")
                        .HasColumnType("longtext");

                    b.Property<string>("Date")
                        .HasColumnType("longtext");

                    b.Property<string>("Department")
                        .HasColumnType("longtext");

                    b.Property<string>("EffectivenessVerification")
                        .HasColumnType("longtext");

                    b.Property<string>("EmpIdDate")
                        .HasColumnType("longtext");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("longtext");

                    b.Property<string>("ErrorType")
                        .HasColumnType("longtext");

                    b.Property<string>("Group")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("IsError")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("IssueType")
                        .HasColumnType("longtext");

                    b.Property<string>("Level1Opportunity")
                        .HasColumnType("longtext");

                    b.Property<string>("Level2Opportunity")
                        .HasColumnType("longtext");

                    b.Property<int>("Lines")
                        .HasColumnType("int");

                    b.Property<string>("Modified")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PreventiveAction")
                        .HasColumnType("longtext");

                    b.Property<string>("Process")
                        .HasColumnType("longtext");

                    b.Property<string>("ProcessChange")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("RootCause")
                        .HasColumnType("longtext");

                    b.Property<string>("Shift")
                        .HasColumnType("longtext");

                    b.Property<string>("TLAnalysis")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("TaskCompletionDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("TeamLeader")
                        .HasColumnType("longtext");

                    b.Property<string>("TicketNumber")
                        .HasColumnType("longtext");

                    b.Property<double>("Volume")
                        .HasColumnType("double");

                    b.Property<string>("WeekRange")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("QualityRating2");
                });

            modelBuilder.Entity("SkillMatrix.Model.QualityRating3", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<string>("AgentName")
                        .HasColumnType("longtext");

                    b.Property<int>("BP1_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("BP1_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("BP2_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("BP2_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("BP3_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("BP3_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("CF1_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("CF1_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("CF2_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("CF2_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("CF3_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("CF3_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("CF4_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("CF4_TotalPoints")
                        .HasColumnType("int");

                    b.Property<double>("CSATScore")
                        .HasColumnType("double");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EmployeeId")
                        .HasColumnType("longtext");

                    b.Property<int>("IC1_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("IC1_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("IC2_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("IC2_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("IC3_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("IC3_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("IC4_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("IC4_TotalPoints")
                        .HasColumnType("int");

                    b.Property<string>("Month")
                        .HasColumnType("longtext");

                    b.Property<int>("NoOfPplOpportunity")
                        .HasColumnType("int");

                    b.Property<double>("PassiveSurvey")
                        .HasColumnType("double");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Remarks")
                        .HasColumnType("longtext");

                    b.Property<int>("SF1_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("SF1_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("SF2_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("SF2_TotalPoints")
                        .HasColumnType("int");

                    b.Property<int>("SF3_PointsEarned")
                        .HasColumnType("int");

                    b.Property<int>("SF3_TotalPoints")
                        .HasColumnType("int");

                    b.Property<string>("TeamLead")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("QualityRating3");
                });

            modelBuilder.Entity("SkillMatrix.Model.TenureLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Level")
                        .HasColumnType("longtext");

                    b.Property<int>("LowerScore")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UpperScore")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TenureLevel");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Novice",
                            LowerScore = 0,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 9
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Advanced Beginner",
                            LowerScore = 10,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 12
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Competent",
                            LowerScore = 13,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 1000
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Proficient",
                            LowerScore = 13,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 1000
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Level = "Expert",
                            LowerScore = 13,
                            UpdatedDate = new DateTime(2022, 1, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            UpperScore = 1000
                        });
                });

            modelBuilder.Entity("SkillMatrix.Model.TicketingTool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AccountType")
                        .HasColumnType("longtext");

                    b.Property<string>("AdditionalComments")
                        .HasColumnType("longtext");

                    b.Property<string>("Comment")
                        .HasColumnType("longtext");

                    b.Property<string>("ConcernedRep")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("RecordDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Remarks")
                        .HasColumnType("longtext");

                    b.Property<string>("Status")
                        .HasColumnType("longtext");

                    b.Property<string>("Team")
                        .HasColumnType("longtext");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TicketingTool");
                });
#pragma warning restore 612, 618
        }
    }
}
