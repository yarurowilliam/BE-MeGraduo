using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.UsuarioServices
{
	public interface IUsuarioService
	{
		Task SaveUserAsync(Usuario usuario);
		Task<Usuario> GetFirstUserInfoAsync(long identificacion);
		Task<bool> ValidateExistenceAsync(Usuario usuario);
		Task<Usuario> ValidatePasswordAsync(long identificacion, string passwordAnterior);
		Task UpdatePasswordAsync(Usuario usuario);
		Task ValidateEmailAsync(Usuario usuario);
		Task<bool> SendMailAsync(long identificacion, string email, string asunto, string mensaje);
        Task<List<Usuario>> GetListAsync();
    }
}
