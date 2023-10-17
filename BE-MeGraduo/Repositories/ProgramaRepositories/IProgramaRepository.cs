using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.ProgramaRepositories
{
    public interface IProgramaRepository
    {
        Task SaveProgramaAsync(Programa item);
        Task<Programa> GetFirstProgramaInfoAsync(string nombrePrograma);
        Task<Programa> GetFirstProgramadInfoByIDAsync(int id);
        Task<bool> ValidateExistenceAsync(Programa item);
        Task<List<Programa>> GetListProgramasAsync();
        Task UpdateProgramaAsync(Programa item);
        Task DeleteProgramaAsync(Programa item);
    }
}
