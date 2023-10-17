using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.SedeRepositories
{
    public interface ISedeRepository
    {
        Task SaveSedeAsync(Sede sede);
        Task<Sede> GetFirstSedeInfoAsync(string nombreSede);
        Task<bool> ValidateExistenceAsync(Sede sede);
        Task<List<Sede>> GetListSedesAsync();
        Task UpdateSedeAsync(Sede sede);
        Task DeleteSedeAsync(Sede sede);
    }
}
