using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.SubModalidadRepositories.Implementation
{
    public class SubModalidadRepository : ISubModalidadRepository
    {
        private readonly AplicationDbContext _context;

        public SubModalidadRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(SubModalidad item)
        {
            _context.SubModalidades.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<SubModalidad> GetFirstInfoAsync(string nombreSubModalidad)
        {
            var model = await _context.SubModalidades.Where(x => x.NombreSubModalidad == nombreSubModalidad).FirstOrDefaultAsync();
            return model;
        }

        public async Task<List<SubModalidad>> GetListAsync()
        {
            var lista = await _context.SubModalidades.Where(x => x.Id != 0).ToListAsync();
            return lista;
        }

        public async Task SaveAsync(SubModalidad item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubModalidad item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(SubModalidad item)
        {
            var validateExistence = await _context.SubModalidades.AnyAsync(x => x.NombreSubModalidad == item.NombreSubModalidad);
            return validateExistence;
        }
    }
}
