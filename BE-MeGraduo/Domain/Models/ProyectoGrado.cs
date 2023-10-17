using System;
using System.Collections.Generic;

namespace BE_MeGraduo.Domain.Models
{
    public class ProyectoGrado
    {
        public int Id { get; set; }
        public int IdModalidad { get; set; }
        public long IdIntegrante1 { get; set; }
        public long? IdIntegrante2 { get; set; }
        public long? IdIntegrante3 { get; set; }
        public string Titulo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string LineaInvestigacion { get; set; }
        public string SubLineaInvestigacion { get; set; }
        public string AreaTematica { get; set; }
        public string GrupoInvestigacion { get; set; }
        public string PlanteamientoProblema { get; set; }
        public string Justificacion { get; set; }
        public string ObjetivoGeneral { get; set; }
        public string ObjetivosEspecificos { get; set; }
        public string Bibliografia { get; set; }
        public long? IdDirector { get; set; }
        public long? IdJurado { get; set; }
        public long? IdJurado2 { get; set; }
        public long? IdAsesor { get; set; }
        public bool? EsAceptadaPropuesta { get; set; }
        public string TipoFase { get; set; }
        public string EstadoProyecto { get; set; }
        public double? Calificacion { get; set; }
        public List<Comentario> Comentarios { get; set; }
    }
}
