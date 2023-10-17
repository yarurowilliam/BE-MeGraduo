using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.UsuarioRolRepositories.Implementation
{
    public class UsuarioRolRepository : IUsuarioRolRepository
    {
        private readonly AplicationDbContext _context;
        public UsuarioRolRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task AsignarRolesAsync(UsuarioRol usuarioRol)
        {
            _context.Add(usuarioRol);
            await _context.SaveChangesAsync();
        }

        public async Task<UsuarioRol> GetFirstAsinacionRolInfoAsync(long identificacion, int idRol)
        {
            var userRol = await _context.UsuarioRoles.Where(x => x.RolId == idRol && x.UsuarioIdentificacion == identificacion).FirstOrDefaultAsync();
            return userRol;
        }

        public async Task RetirarRolAsync(UsuarioRol usuarioRol)
        {
            _context.UsuarioRoles.Remove(usuarioRol);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidarRolExistenteAsync(UsuarioRol usuarioRol)
        {
            var validateExistence = await _context.UsuarioRoles.AnyAsync(x => x.UsuarioIdentificacion == usuarioRol.UsuarioIdentificacion && x.RolId == usuarioRol.RolId);
            return validateExistence;
        }
    }
}
