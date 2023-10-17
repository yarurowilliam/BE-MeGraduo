using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.EstudianteRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.EstudianteServices.Implementation
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _estudianteRepository;
        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }

        public async Task<List<ConsultaEstudianteValidado>> GetEstudiantesValidadosAsync(long identificacion)
        {
            return await _estudianteRepository.GetEstudiantesValidadosAsync(identificacion);
        }

        public async Task<Estudiante> GetFirstInfoAsync(long identificacion)
        {
            return await _estudianteRepository.GetFirstInfoAsync(identificacion);
        }

        public Task<List<ConsultaEstudiante>> GetListAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveInfoAsync(Estudiante estudiante)
        {
            await _estudianteRepository.SaveInfoAsync(estudiante);
        }

        public async Task UpdateEstudianteAsync(Estudiante estudiante)
        {
            await _estudianteRepository.UpdateEstudianteAsync(estudiante);
        }

        public async Task<bool> ValidateExistenceAsync(Estudiante estudiante)
        {
            return await _estudianteRepository.ValidateExistenceAsync(estudiante);
        }
    }
}
