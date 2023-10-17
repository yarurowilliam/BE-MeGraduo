using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.ProgramaServices
{
    public interface IProgramaService
    {
        Task SaveProgramaAsync(Programa item);
        Task<Programa> GetFirstProgramadInfoAsync(string nombrePrograma);
        Task<Programa> GetFirstProgramadInfoByIDAsync(int id);
        Task<bool> ValidateExistenceAsync(Programa item);
        Task<List<Programa>> GetListProgramasAsync();
        Task UpdateProgramaAsync(Programa item);
        Task DeleteProgramaAsync(Programa item);
    }
}
