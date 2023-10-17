using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class IntegrationWithSQLServer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    Identificacion = table.Column<long>(type: "bigint", nullable: false),
                    PrimerNombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "varchar(50)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", nullable: false),
                    IdPrograma = table.Column<int>(type: "int", nullable: false),
                    CreditosAprobados = table.Column<int>(type: "int", nullable: false),
                    Modalidad = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: true),
                    TieneProyecto = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Facultades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreFacultad = table.Column<string>(type: "varchar(100)", nullable: true),
                    SedeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<long>(type: "bigint", nullable: false),
                    PrimerNombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    SegundoNombre = table.Column<string>(type: "varchar(50)", nullable: true),
                    PrimerApellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    SegundoApellido = table.Column<string>(type: "varchar(50)", nullable: true),
                    Telefono = table.Column<string>(type: "varchar(15)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Programas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePrograma = table.Column<string>(type: "varchar(100)", nullable: true),
                    NumeroCreditos = table.Column<int>(type: "int", nullable: false),
                    FacultadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreRol = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sedes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreSede = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sedes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioIdentificacion = table.Column<long>(type: "bigint", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Identificacion = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstadoUsuario = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Identificacion);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_Email",
                table: "Personas",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "Facultades");

            migrationBuilder.DropTable(
                name: "Personas");

            migrationBuilder.DropTable(
                name: "Programas");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Sedes");

            migrationBuilder.DropTable(
                name: "UsuarioRoles");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
