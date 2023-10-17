using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.ModalidadRepositories.Implementation
{
    public class ModalidadRepository : IModalidadRepository
    {
        private readonly AplicationDbContext _context;

        public ModalidadRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Modalidad item)
        {
            _context.Modalidades.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Modalidad> GetFirstInfoAsync(string nombreModalidad)
        {
            var model = await _context.Modalidades.Where(x => x.NombreModalidad == nombreModalidad).FirstOrDefaultAsync();
            return model;
        }

        public async Task<List<Modalidad>> GetListAsync()
        {
            var lista = await _context.Modalidades.Where(x => x.Id != 0).ToListAsync();
            return lista;
        }

        public async Task SaveAsync(Modalidad item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Modalidad item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(Modalidad item)
        {
            var validateExistence = await _context.Modalidades.AnyAsync(x => x.NombreModalidad == item.NombreModalidad);
            return validateExistence;
        }
    }
}
