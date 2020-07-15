using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Data.Migrations
{
    public partial class Page4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PreTreatmentCheck",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InformedConsent = table.Column<bool>(nullable: false),
                    BloodConsent = table.Column<bool>(nullable: false),
                    MachinePrimeId = table.Column<int>(nullable: false),
                    machinePrimed = table.Column<int>(nullable: false),
                    AlarmTest = table.Column<bool>(nullable: false),
                    UniversalPrecautions = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreTreatmentCheck", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreTreatmentCheck");
        }
    }
}
