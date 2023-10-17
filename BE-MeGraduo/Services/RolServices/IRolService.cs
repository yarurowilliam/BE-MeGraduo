using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.RolServices
{
	public interface IRolService
	{
		Task SaveRolAsync(Rol rol);
		Task<Rol> GetFirstRolInfoAsync(string nombreRol);
		Task<bool> ValidateExistenceAsync(Rol rol);
		Task<List<Rol>> GetListRolesAsync();
		Task UpdateRolAsync(Rol rol);
		Task DeleteRolAsync(Rol rol);
	}
}
