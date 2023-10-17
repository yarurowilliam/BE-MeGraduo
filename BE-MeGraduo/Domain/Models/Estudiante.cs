using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_MeGraduo.Domain.Models
{
	public class Estudiante
	{
		[Key]
		public long Identificacion { get; set; }
		[Column(TypeName = "int")]
		public int IdPrograma { get; set; }
		[Column(TypeName = "int")]
		public int CreditosAprobados { get; set; }
		[Column(TypeName = "int")]
		public int Modalidad { get; set; }
        [Column(TypeName = "int")]
        public int SubModalidad { get; set; }
        [Column(TypeName = "varchar(50)")]
		public string Estado { get; set; }
		public bool TieneProyecto { get; set; }
	}
}
