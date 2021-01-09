using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class EditTotalPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "ReservationSeats",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<float>(
                name: "TotalPrice",
                table: "Payments",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$4RJtYU6aF26yIJDW5IttC.9A75rUUhWrfePFcwuhL6A11.4sD31iS", "$2b$06$3qS4FYOiAl.r6JH5VzWjne" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "ReservationSeats",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<int>(
                name: "TotalPrice",
                table: "Payments",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$jgSKxETX89WZicA3t2hrTun2dCFUH3fpC1ch0vZ.yGULYgxf9aYyy", "$2b$06$tTJj4E83Gg1j1naShPgxs." });
        }
    }
}
