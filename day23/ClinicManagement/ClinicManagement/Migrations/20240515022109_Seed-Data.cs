using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManagement.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "Id", "Experience", "Name" },
                values: new object[,]
                {
                    { 1, 10, "Dr. Smith" },
                    { 2, 8, "Dr. Johnson" },
                    { 3, 15, "Dr. Lee" },
                    { 4, 12, "Dr. Patel" },
                    { 5, 7, "Dr. Garcia" },
                    { 6, 20, "Dr. Tanaka" },
                    { 7, 18, "Dr. Müller" },
                    { 8, 5, "Dr. Dupont" },
                    { 9, 14, "Dr. Rossi" },
                    { 10, 11, "Dr. Sato" }
                });

            migrationBuilder.InsertData(
                table: "Specialities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cardiology" },
                    { 2, "Dermatology" },
                    { 3, "Pediatrics" },
                    { 4, "Orthopedics" },
                    { 5, "Oncology" },
                    { 6, "Neurology" },
                    { 7, "Gynecology" },
                    { 8, "Psychiatry" },
                    { 9, "Gastroenterology" },
                    { 10, "Ophthalmology" }
                });

            migrationBuilder.InsertData(
                table: "DoctorSpecialities",
                columns: new[] { "DoctorId", "SpecialityId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "DoctorSpecialities",
                keyColumns: new[] { "DoctorId", "SpecialityId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Specialities",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
