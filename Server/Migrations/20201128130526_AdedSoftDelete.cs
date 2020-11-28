using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AdedSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "SoftDeleted",
                table: "Reservations",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoftDeleted",
                table: "Reservations");
        }
    }
}
