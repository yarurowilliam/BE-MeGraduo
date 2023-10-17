using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class AddingProyuectosDeGrado2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilesProyectosGrados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProyecto = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesProyectosGrados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformacionProyectosGradoFase1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProyectoGrado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Planteamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormulacionProblema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Justificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoEspecifico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcoReferencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcoMetodologico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultadosEsperados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cronograma = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Presupuesto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bibliografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionProyectosGradoFase1", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformacionProyectosGradoFase2",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProyectoGrado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Planteamiento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormulacionProblema = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Justificacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoGeneral = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObjetivoEspecifico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcoReferencial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MarcoMetodologico = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resultado_Analisis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Conclusiones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recomendaciones = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bibliografia = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformacionProyectosGradoFase2", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesProyectosGrados");

            migrationBuilder.DropTable(
                name: "InformacionProyectosGradoFase1");

            migrationBuilder.DropTable(
                name: "InformacionProyectosGradoFase2");
        }
    }
}
