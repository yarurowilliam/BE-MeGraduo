using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_MeGraduo.Domain.Models
{
    public class SubModalidad
    {
        [Key]
        public int Id { get; set; }
        public int ModalidadID { get; set; }
        [Column(TypeName = "varchar(100)")]
        public string NombreSubModalidad { get; set; }
    }
}
