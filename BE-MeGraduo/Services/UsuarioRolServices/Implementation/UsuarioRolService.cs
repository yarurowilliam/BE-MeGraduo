using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.UsuarioRolRepositories;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.UsuarioRolServices.Implementation
{
    public class UsuarioRolService : IUsuarioRolService
    {
        private readonly IUsuarioRolRepository _usuarioRolRepository;

        public UsuarioRolService(IUsuarioRolRepository usuarioRolRepository)
        {
            _usuarioRolRepository = usuarioRolRepository;
        }

        public async Task AsignarRolesAsync(UsuarioRol usuarioRol)
        {
            await _usuarioRolRepository.AsignarRolesAsync(usuarioRol);
        }

        public async Task<UsuarioRol> GetFirstAsinacionRolInfoAsync(long identificacion, int idRol)
        {
            return await _usuarioRolRepository.GetFirstAsinacionRolInfoAsync(identificacion, idRol);
        }

        public async Task RetirarRolAsync(UsuarioRol usuarioRol)
        {
            await _usuarioRolRepository.RetirarRolAsync(usuarioRol);
        }

        public async Task<bool> ValidarRolExistenteAsync(UsuarioRol usuarioRol)
        {
            return await _usuarioRolRepository.ValidarRolExistenteAsync(usuarioRol);
        }
    }
}
