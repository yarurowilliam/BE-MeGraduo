using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class AddingDocente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "varchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)");

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Identificacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPrograma = table.Column<int>(type: "int", nullable: false),
                    Enfasis = table.Column<string>(type: "varchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Identificacion);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "varchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);
        }
    }
}
