using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBookingManager.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Cars_ReservedCarId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_ReservedCarId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservedCarId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cars");

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

            migrationBuilder.AddColumn<string>(
                name: "PersonalNo",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNo",
                table: "Cars",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "PersonalNo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "RegistrationNo");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "CustomerPersonalNo",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ReservedCarRegistrationNo",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PersonalNo",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "RegistrationNo",
                table: "Cars");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReservedCarId",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Customers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Cars",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservedCarId",
                table: "Reservations",
                column: "ReservedCarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Cars_ReservedCarId",
                table: "Reservations",
                column: "ReservedCarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
