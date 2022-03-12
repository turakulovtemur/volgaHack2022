using Microsoft.EntityFrameworkCore.Migrations;

namespace volgaHack.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Applications_ApplicationsId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ApplicationsId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ApplicationsId",
                table: "Events");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationId",
                table: "Events",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Applications_ApplicationId",
                table: "Events",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Applications_ApplicationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ApplicationId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationsId",
                table: "Events",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ApplicationsId",
                table: "Events",
                column: "ApplicationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Applications_ApplicationsId",
                table: "Events",
                column: "ApplicationsId",
                principalTable: "Applications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
