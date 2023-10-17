using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.LoginRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.LoginServices.Implementation
{
	public class LoginService : ILoginService
	{

		private readonly ILoginRepository _loginRepository;
		public LoginService(ILoginRepository loginRepository)
		{
			_loginRepository = loginRepository;
		}

		public async Task<Usuario> ValidateUserAsync(Usuario usuario)
		{
			return await _loginRepository.ValidateUserAsync(usuario);
		}

		public async Task<List<UsuarioRol>> ValidateRolAsync(Usuario usuario)
		{
			return await _loginRepository.ValidateRolAsync(usuario);
		}
	}
}
