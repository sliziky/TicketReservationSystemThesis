using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedSessionsId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SessionId",
                table: "Payments",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$xLPYqrqgGx1gVocQ94XOlOFZzLuHBDoTp6ulqK9ZTNdLCgZq0tE9y", "$2b$06$5d6CBwtwEDICYjHujmJjCu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "Payments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$e340EcBabEmssA./wbyl3.2G3lIUxSEGx8Tt56W2RdcOM.N33kHYi", "$2b$06$zLsnQ6/v.k/kMQaJKD/R4." });
        }
    }
}
