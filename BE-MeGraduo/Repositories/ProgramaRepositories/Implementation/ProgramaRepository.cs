using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.ProgramaRepositories.Implementation
{
    public class ProgramaRepository : IProgramaRepository
    {
        private readonly AplicationDbContext _context;

        public ProgramaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteProgramaAsync(Programa item)
        {
            _context.Programas.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Programa> GetFirstProgramadInfoByIDAsync(int id)
        {
            var programa = await _context.Programas.Where(x => x.Id == id).FirstOrDefaultAsync();
            return programa;
        }

        public async Task<Programa> GetFirstProgramaInfoAsync(string nombrePrograma)
        {
            var programa = await _context.Programas.Where(x => x.NombrePrograma == nombrePrograma).FirstOrDefaultAsync();
            return programa;
        }

        public async Task<List<Programa>> GetListProgramasAsync()
        {
            var lista = await _context.Programas.Where(x => x.Id != 0).ToListAsync();
            return lista;
        }

        public async Task SaveProgramaAsync(Programa item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProgramaAsync(Programa item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(Programa item)
        {
            var validateExistence = await _context.Programas.AnyAsync(x => x.NombrePrograma == item.NombrePrograma);
            return validateExistence;
        }
    }
}
