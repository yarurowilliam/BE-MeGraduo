using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.EstudianteRepositories.Implementation
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private readonly AplicationDbContext _context;

        public EstudianteRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ConsultaEstudianteValidado>> GetEstudiantesValidadosAsync(long identificacion)
        {
            var parametro = new SqlParameter("@ExcluirIdentificacion", identificacion);

            var result = await _context.ConsultaEstudianteValidados.FromSqlRaw("EXEC PA_OBTENER_ESTUDIANTES_VALIDOS_PROYECTO_GRADO @ExcluirIdentificacion", parametro).ToListAsync();
            return result;
        }

        public async Task<Estudiante> GetFirstInfoAsync(long identificacion)
        {
            var estudiante = await _context.Estudiantes.Where(x => x.Identificacion == identificacion).FirstOrDefaultAsync();
            return estudiante;
        }

        public Task<List<ConsultaEstudiante>> GetListAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task SaveInfoAsync(Estudiante estudiante)
        {
            _context.Add(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEstudianteAsync(Estudiante estudiante)
        {
            _context.Update(estudiante);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(Estudiante estudiante)
        {
            var validateExistence = await _context.Estudiantes.AnyAsync(x => x.Identificacion == estudiante.Identificacion);
            return validateExistence;
        }
    }
}
