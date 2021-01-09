using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class NewM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CinemaEmailAccount");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Cinemas",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "TicketPriceId",
                table: "Cinemas",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TicketPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Adult = table.Column<string>(type: "TEXT", nullable: true),
                    Child = table.Column<string>(type: "TEXT", nullable: true),
                    Senior = table.Column<string>(type: "TEXT", nullable: true),
                    Student = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPrices", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$8/g7.VhMKvdwDIMHgxyFoOhOouTGLylRN7epO7pZfwuVqwmKNvyEy", "$2b$06$3prM9nvWkmj2rKGCmfMspO" });

            migrationBuilder.CreateIndex(
                name: "IX_Cinemas_TicketPriceId",
                table: "Cinemas",
                column: "TicketPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cinemas_TicketPrices_TicketPriceId",
                table: "Cinemas",
                column: "TicketPriceId",
                principalTable: "TicketPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cinemas_TicketPrices_TicketPriceId",
                table: "Cinemas");

            migrationBuilder.DropTable(
                name: "TicketPrices");

            migrationBuilder.DropIndex(
                name: "IX_Cinemas_TicketPriceId",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "TicketPriceId",
                table: "Cinemas");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Cinemas",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "CinemaEmailAccount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CinemaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Salt = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaEmailAccount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CinemaEmailAccount_Cinemas_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "CinemaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$YuYGkJkHR9AHGk0OxHbsNu9K/WaVd3BaGrIVwCSMQcelFXljXC0jC", "$2b$06$.HFUeHbe2ORGehq3pUufG." });

            migrationBuilder.CreateIndex(
                name: "IX_CinemaEmailAccount_CinemaId",
                table: "CinemaEmailAccount",
                column: "CinemaId",
                unique: true);
        }
    }
}
