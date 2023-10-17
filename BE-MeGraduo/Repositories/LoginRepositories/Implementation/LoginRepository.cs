using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.LoginRepositories.Implementation
{
	public class LoginRepository : ILoginRepository
	{
		private readonly AplicationDbContext _context;

		public LoginRepository(AplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<UsuarioRol>> ValidateRolAsync(Usuario usuario)
		{
            var userRolesWithRoleNames = await _context.UsuarioRoles
                .Where(usuarioRol => usuarioRol.UsuarioIdentificacion == usuario.Identificacion)
                .Join(_context.Roles,
                      usuarioRol => usuarioRol.RolId,
                      rol => rol.Id,
                      (usuarioRol, rol) => new UsuarioRol
                      {
                          Id = usuarioRol.Id,
                          UsuarioIdentificacion = usuarioRol.UsuarioIdentificacion,
                          RolId = usuarioRol.RolId,
                          RolName = rol.NombreRol
                      })
                .ToListAsync();

            return userRolesWithRoleNames;
		}

		public async Task<Usuario> ValidateUserAsync(Usuario usuario)
		{
			var user = await _context.Usuarios.Where(x => x.Identificacion == usuario.Identificacion && x.Password == usuario.Password).FirstOrDefaultAsync();
			return user;
		}
	}
}
