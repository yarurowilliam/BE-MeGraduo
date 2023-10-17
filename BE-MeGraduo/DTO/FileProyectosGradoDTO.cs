namespace BE_MeGraduo.DTO
{
    public class FileProyectosGradoDTO
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileData { get; set; } // Esto podría ser una cadena Base64 u otra forma de representar los datos del archivo.
                                             // Otras propiedades que puedas necesitar.
    }
}
