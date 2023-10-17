using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.SubModalidadRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.SubModalidadService.Implementation
{
    public class SubModalidadService : ISubModalidadService
    {
        private readonly ISubModalidadRepository _repository;
        public SubModalidadService(ISubModalidadRepository subModalidadRepository)
        {
            _repository = subModalidadRepository;
        }

        public async Task DeleteAsync(SubModalidad item)
        {
            await _repository.DeleteAsync(item);
        }

        public async Task<SubModalidad> GetFirstInfoAsync(string nombreSubModalidad)
        {
            return await _repository.GetFirstInfoAsync(nombreSubModalidad);
        }

        public async Task<List<SubModalidad>> GetListAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task SaveAsync(SubModalidad item)
        {
            await _repository.SaveAsync(item);
        }

        public async Task UpdateAsync(SubModalidad item)
        {
            await _repository.UpdateAsync(item);
        }

        public async Task<bool> ValidateExistenceAsync(SubModalidad item)
        {
            return await _repository.ValidateExistenceAsync(item);
        }
    }
}
