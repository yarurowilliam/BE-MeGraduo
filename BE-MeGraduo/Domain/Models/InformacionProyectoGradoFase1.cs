using System;

namespace BE_MeGraduo.Domain.Models
{
    public class InformacionProyectoGradoFase1
    {
        public int Id { get; set; }
        public int IdProyectoGrado { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
    }
}
