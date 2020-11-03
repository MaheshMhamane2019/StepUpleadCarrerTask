using Microsoft.EntityFrameworkCore.Migrations;

namespace StepUpLeadCareersTask.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comapanys",
                columns: table => new
                {
                    CompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(250)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(250)", nullable: false),
                    Email = table.Column<string>(type: "varchar(250)", nullable: false),
                    CompanyName = table.Column<string>(type: "varchar(250)", nullable: false),
                    CompanySize = table.Column<string>(type: "varchar(250)", nullable: false),
                    JobRole = table.Column<string>(type: "varchar(250)", nullable: false),
                    JobDepartment = table.Column<string>(type: "varchar(250)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(250)", nullable: false),
                    Country = table.Column<string>(type: "varchar(250)", nullable: false),
                    UserIpAddress = table.Column<string>(type: "varchar(250)", nullable: true),
                    UserBrowserDetails = table.Column<string>(type: "varchar(300)", nullable: true),
                    UserOsInfroamtion = table.Column<string>(type: "varchar(300)", nullable: true),
                    LinkPageUrl = table.Column<string>(type: "varchar(300)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comapanys", x => x.CompanyId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comapanys");
        }
    }
}
