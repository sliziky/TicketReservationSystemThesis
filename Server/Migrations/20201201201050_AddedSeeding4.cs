using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class AddedSeeding4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_Admins_UserId",
                table: "Admins");

            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdminId1",
                table: "Users",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$VTtiEu3L1U.9.ql84lIMO.hcQlZKirjQovOZ7OS/MqlVHqP.oYHHu", "$2b$06$0i92pVTArAXwIJZ2Vy7gmO" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_AdminId1",
                table: "Users",
                column: "AdminId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Admins_AdminId1",
                table: "Users",
                column: "AdminId1",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Admins_AdminId1",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_AdminId1",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AdminId1",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$LzxAG7xehRDcr7C8RnY84OtsfSxcBR8fU7t.YTQ2EuiO/p4Y0DZSS", "$2b$06$w9rD/vOWMkvtbcb172IVSO" });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_UserId",
                table: "Admins",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_UserId",
                table: "Admins",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
