using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_MeGraduo.Migrations
{
	public partial class October160841pm : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
			name: "Docentes",
			columns: table => new
			{
				Identificacion = table.Column<long>(type: "bigint", nullable: false),
				IdPrograma = table.Column<int>(type: "int", nullable: false),
				Enfasis = table.Column<string>(type: "varchar(100)", nullable: true),
				Estado = table.Column<string>(type: "varchar(50)", nullable: true)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Docentes", x => x.Identificacion);
			});
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{

		}
	}
}
