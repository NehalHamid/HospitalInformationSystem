using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class thirteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_xrays",
                table: "xrays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tests",
                table: "tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservations",
                table: "reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_requests",
                table: "requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_feedBacks",
                table: "feedBacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clinics",
                table: "clinics");

            migrationBuilder.RenameTable(
                name: "xrays",
                newName: "Xrays");

            migrationBuilder.RenameTable(
                name: "tests",
                newName: "Tests");

            migrationBuilder.RenameTable(
                name: "reservations",
                newName: "Reservations");

            migrationBuilder.RenameTable(
                name: "requests",
                newName: "Requests");

            migrationBuilder.RenameTable(
                name: "feedBacks",
                newName: "FeedBacks");

            migrationBuilder.RenameTable(
                name: "clinics",
                newName: "Clinics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Xrays",
                table: "Xrays",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tests",
                table: "Tests",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Requests",
                table: "Requests",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FeedBacks",
                table: "FeedBacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Xrays",
                table: "Xrays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tests",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Requests",
                table: "Requests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FeedBacks",
                table: "FeedBacks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clinics",
                table: "Clinics");

            migrationBuilder.RenameTable(
                name: "Xrays",
                newName: "xrays");

            migrationBuilder.RenameTable(
                name: "Tests",
                newName: "tests");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "reservations");

            migrationBuilder.RenameTable(
                name: "Requests",
                newName: "requests");

            migrationBuilder.RenameTable(
                name: "FeedBacks",
                newName: "feedBacks");

            migrationBuilder.RenameTable(
                name: "Clinics",
                newName: "clinics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_xrays",
                table: "xrays",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tests",
                table: "tests",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservations",
                table: "reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_requests",
                table: "requests",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_feedBacks",
                table: "feedBacks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clinics",
                table: "clinics",
                column: "Id");
        }
    }
}
