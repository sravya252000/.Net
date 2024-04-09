using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class f : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_DoctorSpecializations_DoctorSpecializationId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_DoctorSpecializationId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "DoctorSpecializationId",
                table: "Doctors");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Patients",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Patients",
                newName: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Patients",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Patients",
                newName: "id");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Patients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DoctorSpecializationId",
                table: "Doctors",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_DoctorSpecializationId",
                table: "Doctors",
                column: "DoctorSpecializationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_DoctorSpecializations_DoctorSpecializationId",
                table: "Doctors",
                column: "DoctorSpecializationId",
                principalTable: "DoctorSpecializations",
                principalColumn: "Id");
        }
    }
}
