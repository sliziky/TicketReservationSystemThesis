using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedGatewayApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GatewayApiKey",
                table: "Cinemas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GatewayApiKey",
                table: "Cinemas");
        }
    }
}
