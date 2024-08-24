using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class fourteen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Xrays",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Tests",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Requests",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Xrays",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Xrays");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Xrays",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tests",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Requests",
                newName: "ID");
        }
    }
}
