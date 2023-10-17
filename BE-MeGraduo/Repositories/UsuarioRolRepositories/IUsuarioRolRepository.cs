using BE_MeGraduo.Domain.Models;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.UsuarioRolRepositories
{
    public interface IUsuarioRolRepository
    {
        Task AsignarRolesAsync(UsuarioRol usuarioRol);
        Task<bool> ValidarRolExistenteAsync(UsuarioRol usuarioRol);
        Task RetirarRolAsync(UsuarioRol usuarioRol);
        Task<UsuarioRol> GetFirstAsinacionRolInfoAsync(long identificacion, int idRol);
    }
}
