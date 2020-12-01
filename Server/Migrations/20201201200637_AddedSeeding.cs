using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "Name", "Password", "PhoneNumber", "Salt" },
                values: new object[] { 1, "admin@admin.com", null, "$2b$10$LzxAG7xehRDcr7C8RnY84OtsfSxcBR8fU7t.YTQ2EuiO/p4Y0DZSS", null, "$2b$06$w9rD/vOWMkvtbcb172IVSO" });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "AdminId", "UserId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "AdminId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
