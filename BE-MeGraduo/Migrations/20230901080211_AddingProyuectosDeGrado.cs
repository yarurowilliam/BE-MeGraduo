using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class AddingProyuectosDeGrado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProyectosDeGrado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdModalidad = table.Column<int>(type: "int", nullable: false),
                    IdIntegrante1 = table.Column<long>(type: "bigint", nullable: false),
                    IdIntegrante2 = table.Column<long>(type: "bigint", nullable: true),
                    IdDirector = table.Column<long>(type: "bigint", nullable: true),
                    IdCalificador = table.Column<long>(type: "bigint", nullable: true),
                    TipoFase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoProyecto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Calificacion = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectosDeGrado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProyectoGradoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentario_ProyectosDeGrado_ProyectoGradoId",
                        column: x => x.ProyectoGradoId,
                        principalTable: "ProyectosDeGrado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_ProyectoGradoId",
                table: "Comentario",
                column: "ProyectoGradoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "ProyectosDeGrado");
        }
    }
}
