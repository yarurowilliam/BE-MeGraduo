using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_MeGraduo.Domain.Models
{
	public class UsuarioRol
	{
		[Key]
		public int Id { get; set; }
		public long UsuarioIdentificacion { get; set; }
		public int RolId { get; set; }
		[NotMapped]
		public string RolName { get; set; }
	}
}
