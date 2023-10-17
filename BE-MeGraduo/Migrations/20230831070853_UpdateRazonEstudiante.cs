using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class UpdateRazonEstudiante : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "PrimerNombre",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "SegundoApellido",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "SegundoNombre",
                table: "Estudiantes");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Estudiantes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Estudiantes",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Estudiantes",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "Estudiantes",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimerNombre",
                table: "Estudiantes",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SegundoApellido",
                table: "Estudiantes",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombre",
                table: "Estudiantes",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Estudiantes",
                type: "varchar(15)",
                nullable: false,
                defaultValue: "");
        }
    }
}
