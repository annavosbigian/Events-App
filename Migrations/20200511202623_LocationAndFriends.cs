using Microsoft.EntityFrameworkCore.Migrations;

namespace RSVPTake3.Migrations
{
    public partial class LocationAndFriends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Friends",
                table: "Event",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LocationName",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Friends",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "LocationName",
                table: "Event");
        }
    }
}
