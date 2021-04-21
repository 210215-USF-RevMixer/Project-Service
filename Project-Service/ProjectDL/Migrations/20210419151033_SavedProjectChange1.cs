using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics.CodeAnalysis;

namespace ProjectDL.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class SavedProjectChange1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_SavedProject_SavedProjectId",
                table: "Track");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_SavedProject_SavedProjectId",
                table: "UserProject");

            migrationBuilder.AddColumn<string>(
                name: "Pattern",
                table: "SavedProject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SampleIds",
                table: "SavedProject",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Track_SavedProject_SavedProjectId",
                table: "Track",
                column: "SavedProjectId",
                principalTable: "SavedProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_SavedProject_SavedProjectId",
                table: "UserProject",
                column: "SavedProjectId",
                principalTable: "SavedProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Track_SavedProject_SavedProjectId",
                table: "Track");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProject_SavedProject_SavedProjectId",
                table: "UserProject");

            migrationBuilder.DropColumn(
                name: "Pattern",
                table: "SavedProject");

            migrationBuilder.DropColumn(
                name: "SampleIds",
                table: "SavedProject");

            migrationBuilder.AddForeignKey(
                name: "FK_Track_SavedProject_SavedProjectId",
                table: "Track",
                column: "SavedProjectId",
                principalTable: "SavedProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProject_SavedProject_SavedProjectId",
                table: "UserProject",
                column: "SavedProjectId",
                principalTable: "SavedProject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
