using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.FacultadRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.FacultadServices.Implementation
{
    public class FacultadService : IFacultadService
    {
        private readonly IFacultadRepository _repository;

        public FacultadService(IFacultadRepository facultad)
        {
            _repository = facultad;
        }

        public async Task DeleteFacultadAsync(Facultad item)
        {
            await _repository.DeleteFacultadAsync(item);
        }

        public async Task<Facultad> GetFirstFacultadInfoAsync(string nombreFacultad)
        {
            return await _repository.GetFirstFacultadInfoAsync(nombreFacultad);
        }

        public async Task<List<Facultad>> GetListFacultadesAsync()
        {
            return await _repository.GetListFacultadesAsync();
        }

        public async Task SaveFacultadAsync(Facultad item)
        {
            await _repository.SaveFacultadAsync(item);
        }

        public async Task UpdateFacultadAsync(Facultad item)
        {
            await _repository.UpdateFacultadAsync(item);
        }

        public async Task<bool> ValidateExistenceAsync(Facultad item)
        {
            return await _repository.ValidateExistenceAsync(item);
        }
    }
}
