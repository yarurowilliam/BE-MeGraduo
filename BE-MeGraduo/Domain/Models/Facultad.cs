using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_MeGraduo.Domain.Models
{
    public class Facultad
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string NombreFacultad { get; set; }
        [Column(TypeName = "int")]
        public int SedeId { get; set; }
    }
}
