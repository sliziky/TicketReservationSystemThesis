using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class ChangedSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$AiSvVap1aV7kdSrK4EOTUu.PPALLCJuWcx6Z8Dg9NxfbwHU/9ABhu", "$2b$06$0eYJig.VCqUidk1cqFsQ0u" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$xLPYqrqgGx1gVocQ94XOlOFZzLuHBDoTp6ulqK9ZTNdLCgZq0tE9y", "$2b$06$5d6CBwtwEDICYjHujmJjCu" });
        }
    }
}
