using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedFkInts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieShows_Halls_HallId",
                table: "MovieShows");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_MovieShows_MovieShowId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_MovieShows_ShowMovieShowId",
                table: "ReservationSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationId",
                table: "ReservationSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_ReservationSeats_ShowMovieShowId",
                table: "ReservationSeats");

            migrationBuilder.DropColumn(
                name: "ShowMovieShowId",
                table: "ReservationSeats");

            migrationBuilder.AlterColumn<int>(
                name: "SeatReservationId",
                table: "Seats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HallId",
                table: "Seats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ReservationSeats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieShowId",
                table: "ReservationSeats",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MovieShowId",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "HallId",
                table: "MovieShows",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSeats_MovieShowId",
                table: "ReservationSeats",
                column: "MovieShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShows_Halls_HallId",
                table: "MovieShows",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_MovieShows_MovieShowId",
                table: "Reservations",
                column: "MovieShowId",
                principalTable: "MovieShows",
                principalColumn: "MovieShowId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_MovieShows_MovieShowId",
                table: "ReservationSeats",
                column: "MovieShowId",
                principalTable: "MovieShows",
                principalColumn: "MovieShowId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationId",
                table: "ReservationSeats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationId",
                table: "Seats",
                column: "SeatReservationId",
                principalTable: "ReservationSeats",
                principalColumn: "SeatReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieShows_Halls_HallId",
                table: "MovieShows");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_MovieShows_MovieShowId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_MovieShows_MovieShowId",
                table: "ReservationSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationId",
                table: "ReservationSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_ReservationSeats_MovieShowId",
                table: "ReservationSeats");

            migrationBuilder.DropColumn(
                name: "MovieShowId",
                table: "ReservationSeats");

            migrationBuilder.AlterColumn<int>(
                name: "SeatReservationId",
                table: "Seats",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "HallId",
                table: "Seats",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "ReservationId",
                table: "ReservationSeats",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "ShowMovieShowId",
                table: "ReservationSeats",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MovieShowId",
                table: "Reservations",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "HallId",
                table: "MovieShows",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSeats_ShowMovieShowId",
                table: "ReservationSeats",
                column: "ShowMovieShowId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShows_Halls_HallId",
                table: "MovieShows",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_MovieShows_MovieShowId",
                table: "Reservations",
                column: "MovieShowId",
                principalTable: "MovieShows",
                principalColumn: "MovieShowId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_MovieShows_ShowMovieShowId",
                table: "ReservationSeats",
                column: "ShowMovieShowId",
                principalTable: "MovieShows",
                principalColumn: "MovieShowId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationId",
                table: "ReservationSeats",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallId",
                table: "Seats",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationId",
                table: "Seats",
                column: "SeatReservationId",
                principalTable: "ReservationSeats",
                principalColumn: "SeatReservationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
