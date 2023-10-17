using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.PersonaRepositories.Implementation
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly AplicationDbContext _context;

        public PersonaRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(Persona persona)
        {
            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<Persona> GetFirstInfoAsync(long identificacion)
        {
            var persona = await _context.Personas.Where(x => x.Identificacion == identificacion).FirstOrDefaultAsync();
            return persona;
        }

        public async Task<List<Persona>> GetListAsync()
        {
            var lista = await _context.Personas.Where(x => x.Identificacion != 0).ToListAsync();
            return lista;
        }

        public async Task SaveInfoAsync(Persona persona)
        {
            _context.Add(persona);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Persona persona)
        {
            _context.Update(persona);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(Persona persona)
        {
            var validateExistence = await _context.Personas.AnyAsync(x => x.Identificacion == persona.Identificacion);
            return validateExistence;
        }
    }
}
