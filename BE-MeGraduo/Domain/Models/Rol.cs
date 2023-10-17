using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_MeGraduo.Domain.Models
{
	public class Rol
	{
        [Key]
        public int Id { get; set; }
		[Required]
		[Column(TypeName = "varchar(50)")]
		public string NombreRol { get; set; }
	}
}
