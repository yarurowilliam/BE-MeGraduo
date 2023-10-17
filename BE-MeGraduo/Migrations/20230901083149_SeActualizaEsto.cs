using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class SeActualizaEsto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bibliografia",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "Conclusiones",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "FormulacionProblema",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "Justificacion",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "MarcoMetodologico",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "MarcoReferencial",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "ObjetivoEspecifico",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "ObjetivoGeneral",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "Planteamiento",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "Recomendaciones",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "Bibliografia",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "Cronograma",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "FormulacionProblema",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "Justificacion",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "MarcoMetodologico",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "MarcoReferencial",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "ObjetivoEspecifico",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "ObjetivoGeneral",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "Planteamiento",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "Presupuesto",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "InformacionProyectosGradoFase2",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "Resultado_Analisis",
                table: "InformacionProyectosGradoFase2",
                newName: "Estado");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "InformacionProyectosGradoFase1",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "ResultadosEsperados",
                table: "InformacionProyectosGradoFase1",
                newName: "Estado");

            migrationBuilder.AddColumn<string>(
                name: "AreaTematica",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bibliografia",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EsAceptadaPropuesta",
                table: "ProyectosDeGrado",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "ProyectosDeGrado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "GropoInvestigacion",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "IdIntegrante3",
                table: "ProyectosDeGrado",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Justificacion",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LineaInvestigacion",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoGeneral",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivosEspecificos",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanteamientoProblema",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubLineaInvestigacion",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Titulo",
                table: "ProyectosDeGrado",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "InformacionProyectosGradoFase2",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "InformacionProyectosGradoFase2",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "InformacionProyectosGradoFase1",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "InformacionProyectosGradoFase1",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaComentario",
                table: "Comentario",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IdPersona",
                table: "Comentario",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaTematica",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "Bibliografia",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "EsAceptadaPropuesta",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "GropoInvestigacion",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "IdIntegrante3",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "Justificacion",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "LineaInvestigacion",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "ObjetivoGeneral",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "ObjetivosEspecificos",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "PlanteamientoProblema",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "SubLineaInvestigacion",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "Titulo",
                table: "ProyectosDeGrado");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "InformacionProyectosGradoFase2");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "InformacionProyectosGradoFase1");

            migrationBuilder.DropColumn(
                name: "FechaComentario",
                table: "Comentario");

            migrationBuilder.DropColumn(
                name: "IdPersona",
                table: "Comentario");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "InformacionProyectosGradoFase2",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "InformacionProyectosGradoFase2",
                newName: "Resultado_Analisis");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "InformacionProyectosGradoFase1",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Estado",
                table: "InformacionProyectosGradoFase1",
                newName: "ResultadosEsperados");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "InformacionProyectosGradoFase2",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Bibliografia",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conclusiones",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormulacionProblema",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Justificacion",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarcoMetodologico",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarcoReferencial",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoEspecifico",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoGeneral",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Planteamiento",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recomendaciones",
                table: "InformacionProyectosGradoFase2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCreacion",
                table: "InformacionProyectosGradoFase1",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Bibliografia",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cronograma",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FormulacionProblema",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Justificacion",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarcoMetodologico",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarcoReferencial",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoEspecifico",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjetivoGeneral",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Planteamiento",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Presupuesto",
                table: "InformacionProyectosGradoFase1",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
