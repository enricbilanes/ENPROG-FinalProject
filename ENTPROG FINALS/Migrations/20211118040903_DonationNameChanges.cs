using Microsoft.EntityFrameworkCore.Migrations;

namespace ENTPROG_FINALS.Migrations
{
    public partial class DonationNameChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_AspNetUsers_UserId1",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_UserId1",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Donations");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Donations");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Donations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_UserId1",
                table: "Donations",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_AspNetUsers_UserId1",
                table: "Donations",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
