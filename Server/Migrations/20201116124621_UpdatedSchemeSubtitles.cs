using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class UpdatedSchemeSubtitles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatSeatReservation");

            migrationBuilder.AddColumn<int>(
                name: "SeatReservationID",
                table: "Seats",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubtitlesLanguage",
                table: "Movies",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeatReservationID",
                table: "Seats",
                column: "SeatReservationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationID",
                table: "Seats",
                column: "SeatReservationID",
                principalTable: "ReservationSeats",
                principalColumn: "SeatReservationID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_ReservationSeats_SeatReservationID",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_SeatReservationID",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "SeatReservationID",
                table: "Seats");

            migrationBuilder.AlterColumn<bool>(
                name: "SubtitlesLanguage",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "SeatSeatReservation",
                columns: table => new
                {
                    ReservationSeatsSeatReservationID = table.Column<int>(type: "INTEGER", nullable: false),
                    SeatsSeatID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatSeatReservation", x => new { x.ReservationSeatsSeatReservationID, x.SeatsSeatID });
                    table.ForeignKey(
                        name: "FK_SeatSeatReservation_ReservationSeats_ReservationSeatsSeatReservationID",
                        column: x => x.ReservationSeatsSeatReservationID,
                        principalTable: "ReservationSeats",
                        principalColumn: "SeatReservationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatSeatReservation_Seats_SeatsSeatID",
                        column: x => x.SeatsSeatID,
                        principalTable: "Seats",
                        principalColumn: "SeatID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatSeatReservation_SeatsSeatID",
                table: "SeatSeatReservation",
                column: "SeatsSeatID");
        }
    }
}
