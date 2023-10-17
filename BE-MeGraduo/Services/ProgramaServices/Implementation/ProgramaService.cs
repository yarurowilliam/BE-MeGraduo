using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.ProgramaRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.ProgramaServices.Implementation
{
    public class ProgramaService : IProgramaService
    {
        private readonly IProgramaRepository _repository;

        public ProgramaService(IProgramaRepository programaRepo)
        {
            _repository = programaRepo;
        }

        public async Task DeleteProgramaAsync(Programa item)
        {
            await _repository.DeleteProgramaAsync(item);
        }

        public async Task<Programa> GetFirstProgramadInfoAsync(string nombrePrograma)
        {
            return await _repository.GetFirstProgramaInfoAsync(nombrePrograma);
        }

        public async Task<Programa> GetFirstProgramadInfoByIDAsync(int id)
        {
            return await _repository.GetFirstProgramadInfoByIDAsync(id);
        }

        public async Task<List<Programa>> GetListProgramasAsync()
        {
            return await _repository.GetListProgramasAsync();
        }

        public async Task SaveProgramaAsync(Programa item)
        {
            await _repository.SaveProgramaAsync(item);
        }

        public async Task UpdateProgramaAsync(Programa item)
        {
            await _repository.UpdateProgramaAsync(item);
        }

        public async Task<bool> ValidateExistenceAsync(Programa item)
        {
            return await _repository.ValidateExistenceAsync(item);
        }
    }
}
