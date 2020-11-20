using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedSeatStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "ReservationSeats");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Seats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ReservationSeats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
