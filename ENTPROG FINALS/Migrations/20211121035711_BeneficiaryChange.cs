using Microsoft.EntityFrameworkCore.Migrations;

namespace ENTPROG_FINALS.Migrations
{
    public partial class BeneficiaryChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beneficiary",
                table: "Donations");

            migrationBuilder.AddColumn<int>(
                name: "BeneficiaryID",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_BeneficiaryID",
                table: "Donations",
                column: "BeneficiaryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Beneficiaries_BeneficiaryID",
                table: "Donations",
                column: "BeneficiaryID",
                principalTable: "Beneficiaries",
                principalColumn: "BeneficiaryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Beneficiaries_BeneficiaryID",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_BeneficiaryID",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "BeneficiaryID",
                table: "Donations");

            migrationBuilder.AddColumn<string>(
                name: "Beneficiary",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
