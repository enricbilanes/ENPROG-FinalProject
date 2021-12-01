using Microsoft.EntityFrameworkCore.Migrations;

namespace ENTPROG_FINALS.Migrations
{
    public partial class BeneficiaryFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Decsription",
                table: "Beneficiaries",
                newName: "Description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Beneficiaries",
                newName: "Decsription");
        }
    }
}
