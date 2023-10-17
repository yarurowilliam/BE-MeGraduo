using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.ModalidadRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.ModalidadServices.Implementation
{
    public class ModalidadService : IModalidadService
    {
        private readonly IModalidadRepository _repository;
        public ModalidadService(IModalidadRepository modalidadRepository)
        {
            _repository = modalidadRepository;
        }

        public async Task DeleteAsync(Modalidad item)
        {
            await _repository.DeleteAsync(item);
        }

        public async Task<Modalidad> GetFirstInfoAsync(string nombreModalidad)
        {
            return await _repository.GetFirstInfoAsync(nombreModalidad);
        }

        public async Task<List<Modalidad>> GetListAsync()
        {
            return await _repository.GetListAsync();
        }

        public async Task SaveAsync(Modalidad item)
        {
            await _repository.SaveAsync(item);
        }

        public async Task UpdateAsync(Modalidad item)
        {
            await _repository.UpdateAsync(item);
        }

        public async Task<bool> ValidateExistenceAsync(Modalidad item)
        {
            return await _repository.ValidateExistenceAsync(item);
        }
    }
}
