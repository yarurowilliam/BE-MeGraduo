using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_MeGraduo.Domain.Models
{
	public class Usuario
	{
		[Key]
        public long Identificacion { get; set; }
        [Column(TypeName = "varchar(50)")]
		public string Email { get; set; }
		[Required]
		[Column(TypeName = "varchar(50)")]
		public string Password { get; set; }
		[Column(TypeName = "varchar(100)")]
		public string EstadoUsuario { get; set; }
		public string RolDefault { get; set; }
	}
}
