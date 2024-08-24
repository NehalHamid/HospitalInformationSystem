using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalInformationSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_History_Doctor_DoctorId",
                table: "History");

            migrationBuilder.DropForeignKey(
                name: "FK_History_Patient_PatientId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_DoctorId",
                table: "History");

            migrationBuilder.DropIndex(
                name: "IX_History_PatientId",
                table: "History");

            migrationBuilder.RenameColumn(
                name: "Examines",
                table: "History",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Doctor",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Report",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Pharmacy",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Nurse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Nurse",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "MedicinesAndItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Medicine",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "HospitalFeedback",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "History",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "History",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "Tests",
                table: "History",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Finance",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "DoctorFeedback",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Gender",
                table: "Doctor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateOnly>(
                name: "BirthDate",
                table: "Doctor",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Department",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Type",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Report");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Pharmacy");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Nurse");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Nurse");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "MedicinesAndItem");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Medicine");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "HospitalFeedback");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "History");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "History");

            migrationBuilder.DropColumn(
                name: "Tests",
                table: "History");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Finance");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "DoctorFeedback");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Doctor");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Department");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "History",
                newName: "Examines");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Doctor",
                newName: "FullName");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "History",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DoctorId",
                table: "History",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Doctor",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_History_Patient_PatientId",
                table: "History",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id");
        }
    }
}
