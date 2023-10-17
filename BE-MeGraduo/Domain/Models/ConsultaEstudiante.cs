namespace BE_MeGraduo.Domain.Models
{
    public class ConsultaEstudiante
    {
        public long Identificacion { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public int SedeID { get; set; }
        public string SedeNombre { get; set; }
        public int FacultadID { get; set; }
        public string FacultadNombre { get; set; }
        public int ProgramaID { get; set; }
        public string ProgramaNombre { get; set; }
        public int CreditosAprobados { get; set; }
        public double PorcentajeCreditos { get; set; }
        public int ModalidadId { get; set; }
        public string ModalidadNombre { get; set; }
        public int SubModalidadId { get; set; }
        public string SubModalidadNombre { get; set; }
        public string Estado { get; set; }
        public string EstadoEstudiante { get; set; }
        public bool TieneProyecto { get; set; }
    }
}
