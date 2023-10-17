using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.EstudianteRepositories;
using BE_MeGraduo.Repositories.PersonaRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.PersonaServices.Implementation
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IEstudianteRepository _estudianteRepository;

        public PersonaService(IPersonaRepository personaRepository, IEstudianteRepository estudianteRepository)
        {
            _personaRepository = personaRepository;
            _estudianteRepository = estudianteRepository;
        }

        public async Task DeleteAsync(Persona persona)
        {
            await _personaRepository.DeleteAsync(persona);
        }

        public async Task<Persona> GetFirstInfoAsync(long identificacion)
        {
            return await _personaRepository.GetFirstInfoAsync(identificacion);
        }

        public async Task<List<Persona>> GetListAsync()
        {
            return await _personaRepository.GetListAsync();
        }

        public async Task SaveInfoAsync(Persona persona)
        {
            await  _personaRepository.SaveInfoAsync(persona);
        }

        public async Task UpdateAsync(Persona persona)
        {
            await _personaRepository.UpdateAsync(persona);
        }

        public async Task<bool> ValidateExistenceAsync(Persona persona)
        {
            return await _personaRepository.ValidateExistenceAsync(persona);
        }
    }
}
