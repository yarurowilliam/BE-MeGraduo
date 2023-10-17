using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.UsuarioRepositories
{
    public interface IUsuarioRepository
    {
        Task SaveUserAsync(Usuario usuario);
		Task<Usuario> GetFirstUserInfoAsync(long identificacion);
		Task<bool> ValidateExistenceAsync(Usuario usuario);
		Task<Usuario> ValidatePasswordAsync(long identificacion, string passwordAnterior);
		Task UpdatePasswordAsync(Usuario usuario);
		Task ValidateEmailAsync(Usuario usuario);
        Task<List<Usuario>> GetListAsync();
    }
}
