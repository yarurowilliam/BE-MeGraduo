using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_MeGraduo.Domain.Models
{
    public class Programa
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string NombrePrograma { get; set; }
        [Column(TypeName = "int")]
        public int NumeroCreditos { get; set; }
        [Column(TypeName = "int")]
        public int FacultadId { get; set; }
    }
}
