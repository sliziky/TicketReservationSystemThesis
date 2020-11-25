using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedObsolete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsObsolete",
                table: "Cinemas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsObsolete",
                table: "Cinemas");
        }
    }
}
