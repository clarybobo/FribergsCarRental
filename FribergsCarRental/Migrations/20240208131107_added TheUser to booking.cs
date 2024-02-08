using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FribergsCarRental.Migrations
{
    /// <inheritdoc />
    public partial class addedTheUsertobooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheUserId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TheUserId",
                table: "Bookings",
                column: "TheUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_TheUsers_TheUserId",
                table: "Bookings",
                column: "TheUserId",
                principalTable: "TheUsers",
                principalColumn: "TheUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_TheUsers_TheUserId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_TheUserId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "TheUserId",
                table: "Bookings");
        }
    }
}
