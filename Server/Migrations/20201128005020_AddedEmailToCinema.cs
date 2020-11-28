using Microsoft.EntityFrameworkCore.Migrations;


namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedEmailToCinema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Cinemas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Cinemas");
        }
    }
}
