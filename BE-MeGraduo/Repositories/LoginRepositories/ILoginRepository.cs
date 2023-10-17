using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.LoginRepositories
{
	public interface ILoginRepository
	{
		Task<Usuario> ValidateUserAsync(Usuario usuario);
		Task<List<UsuarioRol>> ValidateRolAsync(Usuario usuario);
	}
}
