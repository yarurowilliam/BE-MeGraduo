using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.ModalidadRepositories
{
    public interface IModalidadRepository
    {
        Task SaveAsync(Modalidad item);
        Task<Modalidad> GetFirstInfoAsync(string nombreModalidad);
        Task<bool> ValidateExistenceAsync(Modalidad item);
        Task<List<Modalidad>> GetListAsync();
        Task UpdateAsync(Modalidad item);
        Task DeleteAsync(Modalidad item);
    }
}
