using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSettings.BasicWebAPI.Application.Migrations.ApplicationDb
{
    /// <inheritdoc />
    public partial class Correct_RegistrationModel_UserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UerName",
                table: "RegistrationModels",
                newName: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "RegistrationModels",
                newName: "UerName");
        }
    }
}
