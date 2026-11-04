using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data_Hospital_Manager.Migrations
{
    /// <inheritdoc />
    public partial class AddInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Hospitals",
                columns: new[] { "Id", "Address", "BedsCount", "CreatedOn", "Email", "IsDeleted", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "бул. Шипченски проход 15, София", 500, new DateTime(2020, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "info@shipchenska.bg", false, "Болница Шипченска", "+35929876543" },
                    { 2, "ул. Иван Вазов 8, Пловдив", 320, new DateTime(2018, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "contact@svana.bg", false, "Св. Ана", "+35932987654" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "anna.dimova@mail.bg", "Анна", "Димова", "+359889111222" },
                    { 2, "petar.stoyanov@mail.bg", "Петър", "Стоянов", "+359889222333" },
                    { 3, "elena.kevagi@mail.bg", "Елена", "Кевагиева", "+359889333444" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Email", "FirstName", "HospitalId", "LastName", "PhoneNumber", "Specialty" },
                values: new object[,]
                {
                    { 1, "ivan.petrov@hospital.bg", "Иван", 1, "Петров", "+359888123456", "Кардиолог" },
                    { 2, "maria.ivanova@hospital.bg", "Мария", 2, "Иванова", "+359888234567", "Педиатр" },
                    { 3, "georgi.simeonov@hospital.bg", "Георги", 1, "Симеонов", "+359888345678", "Хирург" }
                });

            migrationBuilder.InsertData(
                table: "DoctorPatients",
                columns: new[] { "DoctorId", "PatientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorPatients",
                keyColumns: new[] { "DoctorId", "PatientId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hospitals",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
