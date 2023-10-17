using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.DocenteRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.DocenteServices.Implementation
{
    public class DocenteService : IDocenteService
    {
        private readonly IDocenteRepository _docenteRepository;
        public DocenteService(IDocenteRepository docenteRepository)
        {
            _docenteRepository = docenteRepository;
        }

		public async Task<ConsultaDocenteValidado> GetCompleteInfoDocenteAsync(long identificacion)
		{
            return await _docenteRepository.GetCompleteInfoDocenteAsync(identificacion);
		}

		public async Task<List<ConsultaDocenteValidado>> GetConsultaDocenteValidadosAsync()
		{
            return await _docenteRepository.GetConsultaDocenteValidadosAsync();
		}

		public async Task<Docente> GetFirstInfoAsync(long identificacion)
        {
            return await _docenteRepository.GetFirstInfoAsync(identificacion);    
        }

        public async Task SaveInfoAsync(Docente docente)
        {
            await _docenteRepository.SaveInfoAsync(docente);
        }

        public async Task UpdateAsync(Docente docente)
        {
            await _docenteRepository.UpdateAsync(docente);
        }

        public async Task<bool> ValidateExistenceAsync(Docente docente)
        {
            return await _docenteRepository.ValidateExistenceAsync(docente);
        }
    }
}
