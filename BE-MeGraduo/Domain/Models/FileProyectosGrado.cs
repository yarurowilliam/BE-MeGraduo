namespace BE_MeGraduo.Domain.Models
{
    public class FileProyectosGrado
    {
        public int Id { get; set; }
        public int IdProyecto { get; set; }
        public string FileName { get; set; }
        public byte[] Data { get; set; }
    }
}
