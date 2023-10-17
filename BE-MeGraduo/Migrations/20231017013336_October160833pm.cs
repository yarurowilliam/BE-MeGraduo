using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
    public partial class October160833pm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
		}
    }
}
