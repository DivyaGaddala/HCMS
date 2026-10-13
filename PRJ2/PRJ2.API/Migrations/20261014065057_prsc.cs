using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PRJ2.API.Migrations
{
    /// <inheritdoc />
    public partial class prsc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointmentsss_doctor_DoctorId",
                table: "Appointmentsss");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointmentsss_patients_PatientId",
                table: "Appointmentsss");

            migrationBuilder.DropForeignKey(
                name: "FK_doctor_departments_DepartmentId",
                table: "doctor");

            migrationBuilder.DropIndex(
                name: "IX_doctor_DepartmentId",
                table: "doctor");

            migrationBuilder.DropIndex(
                name: "IX_Appointmentsss_DoctorId",
                table: "Appointmentsss");

            migrationBuilder.DropIndex(
                name: "IX_Appointmentsss_PatientId",
                table: "Appointmentsss");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "doctor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "doctor",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_doctor_DepartmentId",
                table: "doctor",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointmentsss_DoctorId",
                table: "Appointmentsss",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointmentsss_PatientId",
                table: "Appointmentsss",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointmentsss_doctor_DoctorId",
                table: "Appointmentsss",
                column: "DoctorId",
                principalTable: "doctor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointmentsss_patients_PatientId",
                table: "Appointmentsss",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_doctor_departments_DepartmentId",
                table: "doctor",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
