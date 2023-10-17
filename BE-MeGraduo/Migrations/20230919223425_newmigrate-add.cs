using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class newmigrateadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCalificador",
                table: "ProyectosDeGrado",
                newName: "IdJurado2");

            migrationBuilder.AddColumn<long>(
                name: "IdAsesor",
                table: "ProyectosDeGrado",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdJurado",
                table: "ProyectosDeGrado",
                type: "bigint",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdAsesor",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "IdJurado",
                table: "ProyectosDeGrado");

            migrationBuilder.RenameColumn(
                name: "IdJurado2",
                table: "ProyectosDeGrado",
                newName: "IdCalificador");
        }
    }
}
