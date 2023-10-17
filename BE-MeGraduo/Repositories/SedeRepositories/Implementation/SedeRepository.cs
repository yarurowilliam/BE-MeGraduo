using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.SedeRepositories.Implementation
{
    public class SedeRepository : ISedeRepository
    {
        private readonly AplicationDbContext _context;

        public SedeRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteSedeAsync(Sede sede)
        {
            _context.Sedes.Remove(sede);
            await _context.SaveChangesAsync();
        }

        public async Task<Sede> GetFirstSedeInfoAsync(string nombreSede)
        {
            var sede = await _context.Sedes.Where(x => x.NombreSede == nombreSede).FirstOrDefaultAsync();
            return sede;
        }

        public async Task<List<Sede>> GetListSedesAsync()
        {
            var listaSedes = await _context.Sedes.Where(x => x.Id != 0).ToListAsync();
            return listaSedes;
        }

        public async Task SaveSedeAsync(Sede sede)
        {
            _context.Add(sede);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSedeAsync(Sede sede)
        {
            _context.Update(sede);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(Sede sede)
        {
            var validateExistence = await _context.Sedes.AnyAsync(x => x.NombreSede == sede.NombreSede);
            return validateExistence;
        }
    }
}
