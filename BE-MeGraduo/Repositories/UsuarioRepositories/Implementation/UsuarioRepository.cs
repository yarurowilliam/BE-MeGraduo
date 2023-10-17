using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.UsuarioRepositories.Implementation
{
    public class UsuarioRepository : IUsuarioRepository
	{
		private readonly AplicationDbContext _context;
        public UsuarioRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetFirstUserInfoAsync(long identificacion)
		{
			var usuario = await _context.Usuarios.Where(x => x.Identificacion == identificacion).FirstOrDefaultAsync();
			return usuario;
		}

        public async Task<List<Usuario>> GetListAsync()
        {
            var lista = await _context.Usuarios.Where(x => x.Identificacion != 0).ToListAsync();
            return lista;
        }

        public async Task SaveUserAsync(Usuario usuario)
		{
			_context.Add(usuario);
			await _context.SaveChangesAsync();
		}

		public async Task UpdatePasswordAsync(Usuario usuario)
		{
			_context.Update(usuario);
			await _context.SaveChangesAsync();
		}

		public async Task ValidateEmailAsync(Usuario usuario)
		{
			_context.Update(usuario);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> ValidateExistenceAsync(Usuario usuario)
		{
			var validateExistence = await _context.Usuarios.AnyAsync(x => x.Identificacion == usuario.Identificacion || x.Email == usuario.Email);
			return validateExistence;
		}

		public async Task<Usuario> ValidatePasswordAsync(long identificacion, string passwordAnterior)
		{
			var usuario = await _context.Usuarios.Where(x => x.Identificacion == identificacion && x.Password == passwordAnterior).FirstOrDefaultAsync();
			return usuario;
		}
	}
}
