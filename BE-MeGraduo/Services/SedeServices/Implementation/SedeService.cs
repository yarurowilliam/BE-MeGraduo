using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.SedeRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.SedeServices.Implementation
{
    public class SedeService : ISedeService
    {
        private readonly ISedeRepository _repository;
        public SedeService(ISedeRepository repository)
        {
            _repository = repository;
        }

        public async Task DeleteSedeAsync(Sede sede)
        {
            await _repository.DeleteSedeAsync(sede);
        }

        public async Task<Sede> GetFirstSedeInfoAsync(string nombreSede)
        {
            return await _repository.GetFirstSedeInfoAsync(nombreSede);
        }

        public async Task<List<Sede>> GetListSedesAsync()
        {
            return await _repository.GetListSedesAsync();
        }

        public async Task SaveSedeAsync(Sede sede)
        {
            await _repository.SaveSedeAsync(sede);
        }

        public async Task UpdateSedeAsync(Sede sede)
        {
            await _repository.UpdateSedeAsync(sede);
        }

        public async Task<bool> ValidateExistenceAsync(Sede sede)
        {
            return await _repository.ValidateExistenceAsync(sede);
        }
    }
}
