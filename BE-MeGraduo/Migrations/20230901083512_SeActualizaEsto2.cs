using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class SeActualizaEsto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GropoInvestigacion",
                table: "ProyectosDeGrado",
                newName: "GrupoInvestigacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GrupoInvestigacion",
                table: "ProyectosDeGrado",
                newName: "GropoInvestigacion");
        }
    }
}
