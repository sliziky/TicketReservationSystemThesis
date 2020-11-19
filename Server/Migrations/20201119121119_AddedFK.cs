using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserID",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Cinemas_CinemaID",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieShows_Halls_HallID",
                table: "MovieShows");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieShows_Movies_MovieID",
                table: "MovieShows");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_MovieShows_MovieShowID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_MovieShows_ShowMovieShowID",
                table: "ReservationSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationID",
                table: "ReservationSeats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Halls_HallID",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationID",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "SeatReservationID",
                table: "Seats",
                newName: "SeatReservationId");

            migrationBuilder.RenameColumn(
                name: "HallID",
                table: "Seats",
                newName: "HallId");

            migrationBuilder.RenameColumn(
                name: "SeatID",
                table: "Seats",
                newName: "SeatId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_SeatReservationID",
                table: "Seats",
                newName: "IX_Seats_SeatReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_HallID",
                table: "Seats",
                newName: "IX_Seats_HallId");

            migrationBuilder.RenameColumn(
                name: "ShowMovieShowID",
                table: "ReservationSeats",
                newName: "ShowMovieShowId");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "ReservationSeats",
                newName: "ReservationId");

            migrationBuilder.RenameColumn(
                name: "SeatReservationID",
                table: "ReservationSeats",
                newName: "SeatReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeats_ShowMovieShowID",
                table: "ReservationSeats",
                newName: "IX_ReservationSeats_ShowMovieShowId");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeats_ReservationID",
                table: "ReservationSeats",
                newName: "IX_ReservationSeats_ReservationId");

            migrationBuilder.RenameColumn(
                name: "MovieShowID",
                table: "Reservations",
                newName: "MovieShowId");

            migrationBuilder.RenameColumn(
                name: "ReservationID",
                table: "Reservations",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MovieShowID",
                table: "Reservations",
                newName: "IX_Reservations_MovieShowId");

            migrationBuilder.RenameColumn(
                name: "PaymentID",
                table: "Payments",
                newName: "PaymentId");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "MovieShows",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "HallID",
                table: "MovieShows",
                newName: "HallId");

            migrationBuilder.RenameColumn(
                name: "MovieShowID",
                table: "MovieShows",
                newName: "MovieShowId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieShows_MovieID",
                table: "MovieShows",
                newName: "IX_MovieShows_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieShows_HallID",
                table: "MovieShows",
                newName: "IX_MovieShows_HallId");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Movies",
                newName: "MovieId");

            migrationBuilder.RenameColumn(
                name: "CinemaID",
                table: "Halls",
                newName: "CinemaId");

            migrationBuilder.RenameColumn(
                name: "HallID",
                table: "Halls",
                newName: "HallId");

            migrationBuilder.RenameIndex(
                name: "IX_Halls_CinemaID",
                table: "Halls",
                newName: "IX_Halls_CinemaId");

            migrationBuilder.RenameColumn(
                name: "CinemaID",
                table: "Cinemas",
                newName: "CinemaId");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Admins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "Admins",
                newName: "AdminId");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_UserID",
                table: "Admins",
                newName: "IX_Admins_UserId");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaId",
                table: "Halls",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Cinemas_CinemaId",
                table: "Halls",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "CinemaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShows_Halls_HallId",
                table: "MovieShows",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "HallId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShows_Movies_MovieId",
                table: "MovieShows",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Halls_Cinemas_CinemaId",
                table: "Halls");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieShows_Halls_HallId",
                table: "MovieShows");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieShows_Movies_MovieId",
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

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "SeatReservationId",
                table: "Seats",
                newName: "SeatReservationID");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "Seats",
                newName: "HallID");

            migrationBuilder.RenameColumn(
                name: "SeatId",
                table: "Seats",
                newName: "SeatID");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_SeatReservationId",
                table: "Seats",
                newName: "IX_Seats_SeatReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_HallId",
                table: "Seats",
                newName: "IX_Seats_HallID");

            migrationBuilder.RenameColumn(
                name: "ShowMovieShowId",
                table: "ReservationSeats",
                newName: "ShowMovieShowID");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "ReservationSeats",
                newName: "ReservationID");

            migrationBuilder.RenameColumn(
                name: "SeatReservationId",
                table: "ReservationSeats",
                newName: "SeatReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeats_ShowMovieShowId",
                table: "ReservationSeats",
                newName: "IX_ReservationSeats_ShowMovieShowID");

            migrationBuilder.RenameIndex(
                name: "IX_ReservationSeats_ReservationId",
                table: "ReservationSeats",
                newName: "IX_ReservationSeats_ReservationID");

            migrationBuilder.RenameColumn(
                name: "MovieShowId",
                table: "Reservations",
                newName: "MovieShowID");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Reservations",
                newName: "ReservationID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MovieShowId",
                table: "Reservations",
                newName: "IX_Reservations_MovieShowID");

            migrationBuilder.RenameColumn(
                name: "PaymentId",
                table: "Payments",
                newName: "PaymentID");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieShows",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "MovieShows",
                newName: "HallID");

            migrationBuilder.RenameColumn(
                name: "MovieShowId",
                table: "MovieShows",
                newName: "MovieShowID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieShows_MovieId",
                table: "MovieShows",
                newName: "IX_MovieShows_MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieShows_HallId",
                table: "MovieShows",
                newName: "IX_MovieShows_HallID");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Movies",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Halls",
                newName: "CinemaID");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "Halls",
                newName: "HallID");

            migrationBuilder.RenameIndex(
                name: "IX_Halls_CinemaId",
                table: "Halls",
                newName: "IX_Halls_CinemaID");

            migrationBuilder.RenameColumn(
                name: "CinemaId",
                table: "Cinemas",
                newName: "CinemaID");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Admins",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Admins",
                newName: "AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                newName: "IX_Admins_UserID");

            migrationBuilder.AlterColumn<int>(
                name: "CinemaID",
                table: "Halls",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserID",
                table: "Admins",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Halls_Cinemas_CinemaID",
                table: "Halls",
                column: "CinemaID",
                principalTable: "Cinemas",
                principalColumn: "CinemaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShows_Halls_HallID",
                table: "MovieShows",
                column: "HallID",
                principalTable: "Halls",
                principalColumn: "HallID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieShows_Movies_MovieID",
                table: "MovieShows",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_MovieShows_MovieShowID",
                table: "Reservations",
                column: "MovieShowID",
                principalTable: "MovieShows",
                principalColumn: "MovieShowID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_MovieShows_ShowMovieShowID",
                table: "ReservationSeats",
                column: "ShowMovieShowID",
                principalTable: "MovieShows",
                principalColumn: "MovieShowID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_Reservations_ReservationID",
                table: "ReservationSeats",
                column: "ReservationID",
                principalTable: "Reservations",
                principalColumn: "ReservationID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Halls_HallID",
                table: "Seats",
                column: "HallID",
                principalTable: "Halls",
                principalColumn: "HallID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationID",
                table: "Seats",
                column: "SeatReservationID",
                principalTable: "ReservationSeats",
                principalColumn: "SeatReservationID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
