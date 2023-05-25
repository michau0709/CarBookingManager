using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingManager.API.Migrations
{
    /// <inheritdoc />
    public partial class Modify_Reservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_ReservedCarRegistrationNo",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerPersonalNo",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerPersonalNo",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservedCarRegistrationNo",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "CustomerPersonalNo",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservedCarRegistrationNo",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "PersonalNo",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNo",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_PersonalNo",
                table: "Reservations",
                column: "PersonalNo");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RegistrationNo",
                table: "Reservations",
                column: "RegistrationNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_RegistrationNo",
                table: "Reservations",
                column: "RegistrationNo",
                principalTable: "Cars",
                principalColumn: "RegistrationNo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_PersonalNo",
                table: "Reservations",
                column: "PersonalNo",
                principalTable: "Customers",
                principalColumn: "PersonalNo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_RegistrationNo",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_PersonalNo",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_PersonalNo",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RegistrationNo",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PersonalNo",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "RegistrationNo",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "CustomerPersonalNo",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReservedCarRegistrationNo",
                table: "Reservations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerPersonalNo",
                table: "Reservations",
                column: "CustomerPersonalNo");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedCarRegistrationNo",
                table: "Reservations",
                column: "ReservedCarRegistrationNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_ReservedCarRegistrationNo",
                table: "Reservations",
                column: "ReservedCarRegistrationNo",
                principalTable: "Cars",
                principalColumn: "RegistrationNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerPersonalNo",
                table: "Reservations",
                column: "CustomerPersonalNo",
                principalTable: "Customers",
                principalColumn: "PersonalNo");
        }
    }
}
