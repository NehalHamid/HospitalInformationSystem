using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Doctor_DoctorId1",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Patient_PatientId1",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_DoctorId1",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_PatientId1",
                table: "History");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "History");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "XRays",
                table: "History",
                newName: "XRay");

            migrationBuilder.RenameColumn(
                name: "Tests",
                table: "History",
                newName: "Test");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExamenDate",
                table: "History",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "History",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoctorNationalId",
                table: "History",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PatientNationalId",
                table: "History",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tests",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tests", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "xrays",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_xrays", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_DoctorId",
                table: "History",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_History_PatientId",
                table: "History",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Doctor_DoctorId",
                table: "History",
                column: "DoctorId",
                principalTable: "Doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_History_Patient_PatientId",
                table: "History",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Doctor_DoctorId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Patient_PatientId",
                table: "History");

            migrationBuilder.DropTable(
                name: "tests");

            migrationBuilder.DropTable(
                name: "xrays");

            migrationBuilder.DropIndex(
                name: "IX_History_DoctorId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_PatientId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "DoctorNationalId",
                table: "History");

            migrationBuilder.DropColumn(
                name: "PatientNationalId",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "XRay",
                table: "History",
                newName: "XRays");

            migrationBuilder.RenameColumn(
                name: "Test",
                table: "History",
                newName: "Tests");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "History",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "ExamenDate",
                table: "History",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "History",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId1",
                table: "History",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "History",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_History_DoctorId1",
                table: "History",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_History_PatientId1",
                table: "History",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Doctor_DoctorId1",
                table: "History",
                column: "DoctorId1",
                principalTable: "Doctor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Patient_PatientId1",
                table: "History",
                column: "PatientId1",
                principalTable: "Patient",
                principalColumn: "Id");
        }
    }
}
