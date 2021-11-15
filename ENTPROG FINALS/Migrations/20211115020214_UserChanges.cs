using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ENTPROG_FINALS.Migrations
{
    public partial class UserChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Donations");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Donations",
                type: "uniqueidentifier",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_AspNetUsers_UserId1",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_UserId1",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Donations");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Donations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
