using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedSendGridKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SendGridApiKey",
                table: "Cinemas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$ev3GH/VrECrWmJEPoxL.iuyLdROwyqV.WSaXvmalAygENwkOU8gqm", "$2b$06$z/oxoOM26HCQ9TkHD7QT8O" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendGridApiKey",
                table: "Cinemas");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$AiSvVap1aV7kdSrK4EOTUu.PPALLCJuWcx6Z8Dg9NxfbwHU/9ABhu", "$2b$06$0eYJig.VCqUidk1cqFsQ0u" });
        }
    }
}
