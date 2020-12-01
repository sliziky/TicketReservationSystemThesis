using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedSeeding5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "AdminId", "Password", "Salt" },
                values: new object[] { 1, "$2b$10$e340EcBabEmssA./wbyl3.2G3lIUxSEGx8Tt56W2RdcOM.N33kHYi", "$2b$06$zLsnQ6/v.k/kMQaJKD/R4." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "AdminId", "Password", "Salt" },
                values: new object[] { 0, "$2b$10$VTtiEu3L1U.9.ql84lIMO.hcQlZKirjQovOZ7OS/MqlVHqP.oYHHu", "$2b$06$0i92pVTArAXwIJZ2Vy7gmO" });
        }
    }
}
