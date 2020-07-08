using Microsoft.EntityFrameworkCore.Migrations;

namespace RSVPTake3.Migrations
{
    public partial class UpdateData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Response",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "Event");

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Guest",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RSVP",
                table: "Guest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Message",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "RSVP",
                table: "Guest");

            migrationBuilder.AddColumn<bool>(
                name: "Response",
                table: "Guest",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "Event",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
