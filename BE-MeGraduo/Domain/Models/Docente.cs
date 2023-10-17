using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_MeGraduo.Domain.Models
{
    public class Docente
    {
        [Key]
        public long Identificacion { get; set; }
        [Column(TypeName = "int")]
        public int IdPrograma { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string Enfasis { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Estado { get; set; }
    }
}
