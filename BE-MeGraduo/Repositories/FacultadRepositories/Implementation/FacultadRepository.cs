using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.FacultadRepositories.Implementation
{
    public class FacultadRepository : IFacultadRepository
    {
        private readonly AplicationDbContext _context;

        public FacultadRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteFacultadAsync(Facultad item)
        {
            _context.Facultades.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Facultad> GetFirstFacultadInfoAsync(string nombreFacultad)
        {
            var facultad = await _context.Facultades.Where(x => x.NombreFacultad == nombreFacultad).FirstOrDefaultAsync();
            return facultad;
        }

        public async Task<List<Facultad>> GetListFacultadesAsync()
        {
            var lista = await _context.Facultades.Where(x => x.Id != 0).ToListAsync();
            return lista;
        }

        public async Task SaveFacultadAsync(Facultad item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFacultadAsync(Facultad item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(Facultad item)
        {
            var validateExistence = await _context.Facultades.AnyAsync(x => x.NombreFacultad == item.NombreFacultad);
            return validateExistence;
        }
    }
}
