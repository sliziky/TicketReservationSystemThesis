using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedNulalbleFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationId",
                table: "Seats");

            migrationBuilder.AlterColumn<int>(
                name: "SeatReservationId",
                table: "Seats",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationId",
                table: "Seats",
                column: "SeatReservationId",
                principalTable: "ReservationSeats",
                principalColumn: "SeatReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationId",
                table: "Seats");

            migrationBuilder.AlterColumn<int>(
                name: "SeatReservationId",
                table: "Seats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationId",
                table: "Seats",
                column: "SeatReservationId",
                principalTable: "ReservationSeats",
                principalColumn: "SeatReservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
