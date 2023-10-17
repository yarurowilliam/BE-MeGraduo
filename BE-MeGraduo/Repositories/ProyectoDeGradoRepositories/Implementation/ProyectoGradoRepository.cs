using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.ProyectoDeGradoRepositories.Implementation
{
    public class ProyectoGradoRepository : IProyectoGradoRepository
    {
        private readonly AplicationDbContext _context;

        public ProyectoGradoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddFile(FileProyectosGrado file)
        {
            _context.FilesProyectosGrados.Add(file);
            await _context.SaveChangesAsync();
            return file.Id;
        }

        public async Task DeleteAsync(ProyectoGrado item)
        {
            _context.ProyectosDeGrado.Remove(item);
            await _context.SaveChangesAsync();
        }

        public FileProyectosGrado GetFile(int id)
        {
            return _context.FilesProyectosGrados.FirstOrDefault(p => p.Id == id);
        }

        public async Task<ProyectoGrado> GetFirstInfoAsync(int idProyecto)
        {
            var proyecto = await _context.ProyectosDeGrado
                                 .Include(p => p.Comentarios)
                                 .Where(x => x.Id == idProyecto)
                                 .FirstOrDefaultAsync();
            return proyecto;
        }

        public async Task<List<ProyectoGrado>> GetListAsync()
        {
            var lista = await _context.ProyectosDeGrado.Where(x => x.Id != 0).ToListAsync();
            return lista;
        }

        public async Task SaveProyectoAsync(ProyectoGrado item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProyectoGrado item)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(ProyectoGrado item)
        {
            var validateExistence = await _context.ProyectosDeGrado.AnyAsync(x => x.Titulo == item.Titulo);
            return validateExistence;
        }

        public async Task<List<ProyectoGrado>> GetListByDirector(long id)
        {
            var lista = await _context.ProyectosDeGrado.Where(x => x.IdDirector == id).ToListAsync();
            return lista;
        }

        public async Task<List<ProyectoGrado>> GetListByAsesor(long id)
        {
            var lista = await _context.ProyectosDeGrado.Where(x => x.IdAsesor == id).ToListAsync();
            return lista;
        }

        public async Task<List<ProyectoGrado>> GetListByJurado(long id)
        {
            var lista = await _context.ProyectosDeGrado.Where(x => x.IdJurado == id || x.IdJurado2 == id).ToListAsync();
            return lista;
        }

    }
}
