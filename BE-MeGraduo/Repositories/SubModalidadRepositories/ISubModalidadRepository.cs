using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.SubModalidadRepositories
{
    public interface ISubModalidadRepository
    {
        Task SaveAsync(SubModalidad item);
        Task<SubModalidad> GetFirstInfoAsync(string nombreSubModalidad);
        Task<bool> ValidateExistenceAsync(SubModalidad item);
        Task<List<SubModalidad>> GetListAsync();
        Task UpdateAsync(SubModalidad item);
        Task DeleteAsync(SubModalidad item);
    }
}
