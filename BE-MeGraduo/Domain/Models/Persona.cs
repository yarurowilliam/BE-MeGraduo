using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_MeGraduo.Domain.Models
{
	public class Persona
	{
        [Key]
        public long Identificacion { get; set; }
		[Required]
		[Column(TypeName = "varchar(50)")]
		public string PrimerNombre { get; set; }
		[Column(TypeName = "varchar(50)")]
		public string SegundoNombre { get; set; }
		[Required]
		[Column(TypeName = "varchar(50)")]
		public string PrimerApellido { get; set; }
		[Column(TypeName = "varchar(50)")]
		public string SegundoApellido { get; set; }
		[Required]
		[Column(TypeName = "varchar(15)")]
		public string Telefono { get; set; }
		[Required]
		[Column(TypeName = "varchar(50)")]
		public string Email { get; set; }
		[Required]
		[Column(TypeName = "varchar(50)")]
		public string Direccion { get; set; }
    }
}
