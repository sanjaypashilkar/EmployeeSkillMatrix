using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace SkillMatrix.Repository.Migrations
{
    public partial class BusinessPartner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessPartner",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Comments = table.Column<string>(type: "text", nullable: true),
                    Modified = table.Column<string>(type: "text", nullable: true),
                    Valid = table.Column<string>(type: "text", nullable: true),
                    TLRemarks = table.Column<string>(type: "text", nullable: true),
                    Team = table.Column<string>(type: "text", nullable: true),
                    BusinessPartnerNumber = table.Column<double>(type: "double", nullable: false),
                    PartnerCategory = table.Column<int>(type: "int", nullable: false),
                    PartnerType = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Name1 = table.Column<string>(type: "text", nullable: true),
                    Name2 = table.Column<string>(type: "text", nullable: true),
                    Name3 = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Institute1 = table.Column<string>(type: "text", nullable: true),
                    Institute2 = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    HouseNumber = table.Column<string>(type: "text", nullable: true),
                    PostalCode1 = table.Column<string>(type: "text", nullable: true),
                    POBox = table.Column<string>(type: "text", nullable: true),
                    PostalCode2 = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    CountryKey = table.Column<string>(type: "text", nullable: true),
                    EmailAddress = table.Column<string>(type: "text", nullable: true),
                    SalesOrganization1 = table.Column<string>(type: "text", nullable: true),
                    SalesOrganization2 = table.Column<string>(type: "text", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChangedBy = table.Column<string>(type: "text", nullable: true),
                    ChangedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true),
                    RecordDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessPartner", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessPartner");
        }
    }
}
