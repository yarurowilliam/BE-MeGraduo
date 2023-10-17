using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.RolRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.RolServices.Implementation
{
	public class RolService : IRolService
	{
		private readonly IRolRepository _rolRepository;

        public RolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task DeleteRolAsync(Rol rol)
		{
			await _rolRepository.DeleteRolAsync(rol);
		}

		public async Task<Rol> GetFirstRolInfoAsync(string nombreRol)
		{
			return await _rolRepository.GetFirstRolInfoAsync(nombreRol);
		}

		public async Task<List<Rol>> GetListRolesAsync()
		{
			return await _rolRepository.GetListRolesAsync();
		}

		public async Task SaveRolAsync(Rol rol)
		{
			await _rolRepository.SaveRolAsync(rol);
		}

		public async Task UpdateRolAsync(Rol rol)
		{
			await _rolRepository.UpdateRolAsync(rol);
		}

		public async Task<bool> ValidateExistenceAsync(Rol rol)
		{
			return await _rolRepository.ValidateExistenceAsync(rol);
		}
	}
}
