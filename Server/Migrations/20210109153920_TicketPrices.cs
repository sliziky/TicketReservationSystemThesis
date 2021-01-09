using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketReservationSystem.Server.Migrations
{
    public partial class TicketPrices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "TicketPriceAdult",
                table: "Cinemas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketPriceChild",
                table: "Cinemas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketPriceSenior",
                table: "Cinemas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TicketPriceStudent",
                table: "Cinemas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "Password", "Salt" },
                values: new object[] { "$2b$10$jgSKxETX89WZicA3t2hrTun2dCFUH3fpC1ch0vZ.yGULYgxf9aYyy", "$2b$06$tTJj4E83Gg1j1naShPgxs." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPriceAdult",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "TicketPriceChild",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "TicketPriceSenior",
                table: "Cinemas");

            migrationBuilder.DropColumn(
                name: "TicketPriceStudent",
                table: "Cinemas");

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
    }
}
