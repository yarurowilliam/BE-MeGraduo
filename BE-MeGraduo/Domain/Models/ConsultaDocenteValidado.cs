using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_MeGraduo.Domain.Models
{
    public class ConsultaDocenteValidado
    {
        [Key]
        public long Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int IdPrograma { get; set; }
        public string Enfasis { get; set; }
        public string Estado { get; set; }
        public string EstadoUsuario { get; set; }
        public string RolDefault { get; set; }
    }
}
