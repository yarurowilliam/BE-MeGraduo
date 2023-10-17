using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class October160832pm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConsultaEstudianteValidados",
                columns: table => new
                {
                    Identificacion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimerNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoNombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdPrograma = table.Column<int>(type: "int", nullable: false),
                    CreditosAprobados = table.Column<int>(type: "int", nullable: false),
                    Modalidad = table.Column<int>(type: "int", nullable: false),
                    SubModalidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TieneProyecto = table.Column<bool>(type: "bit", nullable: false),
                    RolDefault = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoUsuario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultaEstudianteValidados", x => x.Identificacion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsultaEstudianteValidados");
        }
    }
}
