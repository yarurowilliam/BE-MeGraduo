using System;

namespace BE_MeGraduo.Domain.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaComentario { get; set; }
        public string IdPersona { get; set; }
    }
}
