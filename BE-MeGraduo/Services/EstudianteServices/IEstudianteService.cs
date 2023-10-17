using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.EstudianteServices
{
    public interface IEstudianteService
    {
        Task SaveInfoAsync(Estudiante estudiante);
        Task<Estudiante> GetFirstInfoAsync(long identificacion);
        Task<bool> ValidateExistenceAsync(Estudiante estudiante);
        Task<List<ConsultaEstudiante>> GetListAsync();
        Task UpdateEstudianteAsync(Estudiante estudiante);
        Task<List<ConsultaEstudianteValidado>> GetEstudiantesValidadosAsync(long identificacion);
    }
}
