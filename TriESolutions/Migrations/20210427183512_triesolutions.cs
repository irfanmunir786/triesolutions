using Microsoft.EntityFrameworkCore.Migrations;

namespace TriESolutions.Migrations
{
    public partial class triesolutions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Subject",
                table: "sendEmails",
                newName: "Email");

            migrationBuilder.AddColumn<string>(
                name: "MobilePhone",
                table: "sendEmails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MobilePhone",
                table: "sendEmails");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "sendEmails",
                newName: "Subject");
        }
    }
}
