using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.PersonaRepositories
{
    public interface IPersonaRepository
    {
        Task SaveInfoAsync(Persona persona);
        Task<Persona> GetFirstInfoAsync(long identificacion);
        Task<bool> ValidateExistenceAsync(Persona persona);
        Task<List<Persona>> GetListAsync();
        Task UpdateAsync(Persona persona);
        Task DeleteAsync(Persona persona);
    }
}
