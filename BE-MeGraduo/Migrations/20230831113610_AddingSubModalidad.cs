using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class AddingSubModalidad : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubModalidad",
                table: "Estudiantes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Modalidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreModalidad = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalidades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modalidades");

            migrationBuilder.DropColumn(
                name: "SubModalidad",
                table: "Estudiantes");
        }
    }
}
