using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.LoginServices
{
	public interface ILoginService
	{
		Task<Usuario> ValidateUserAsync(Usuario usuario);
		Task<List<UsuarioRol>> ValidateRolAsync(Usuario usuario);
	}
}
