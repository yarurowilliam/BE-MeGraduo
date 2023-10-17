using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.RolRepositories.Implementation
{
	public class RolRepository : IRolRepository
	{
		private readonly AplicationDbContext _context;

		public RolRepository(AplicationDbContext context)
		{
			_context = context;
		}

		public async Task DeleteRolAsync(Rol rol)
		{
			_context.Roles.Remove(rol);
			await _context.SaveChangesAsync();
		}

		public async Task<Rol> GetFirstRolInfoAsync(string nombreRol)
		{
			var rol = await _context.Roles.Where(x => x.NombreRol == nombreRol).FirstOrDefaultAsync();
			return rol;
		}

		public async Task<List<Rol>> GetListRolesAsync()
		{
			var listaRoles = await _context.Roles.Where(x => x.Id != 0).ToListAsync();
			return listaRoles;
		}

		public async Task SaveRolAsync(Rol rol)
		{
			_context.Add(rol);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateRolAsync(Rol rol)
		{
			_context.Update(rol);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> ValidateExistenceAsync(Rol rol)
		{
			var validateExistence = await _context.Roles.AnyAsync(x => x.NombreRol == rol.NombreRol);
			return validateExistence;
		}
	}
}
