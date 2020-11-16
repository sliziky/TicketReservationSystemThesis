using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class UpdatedSchemeSalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReservationSeats_Seats_SeatID",
                table: "ReservationSeats");

            migrationBuilder.DropIndex(
                name: "IX_ReservationSeats_SeatID",
                table: "ReservationSeats");

            migrationBuilder.DropColumn(
                name: "SeatID",
                table: "ReservationSeats");

            migrationBuilder.RenameColumn(
                name: "ReservationSeatID",
                table: "ReservationSeats",
                newName: "SeatReservationID");

            migrationBuilder.AddColumn<string>(
                name: "Salt",
                table: "Users",
                type: "TEXT",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SeatSeatReservation");

            migrationBuilder.DropColumn(
                name: "Salt",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "SeatReservationID",
                table: "ReservationSeats",
                newName: "ReservationSeatID");

            migrationBuilder.AddColumn<int>(
                name: "SeatID",
                table: "ReservationSeats",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReservationSeats_SeatID",
                table: "ReservationSeats",
                column: "SeatID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReservationSeats_Seats_SeatID",
                table: "ReservationSeats",
                column: "SeatID",
                principalTable: "Seats",
                principalColumn: "SeatID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
