using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.DocenteRepositories.Implementation
{
    public class DocenteRepository : IDocenteRepository
    {
        private readonly AplicationDbContext _context;

        public DocenteRepository(AplicationDbContext context)
        {
            _context = context;
        }

		public async Task<ConsultaDocenteValidado> GetCompleteInfoDocenteAsync(long identificacion)
		{
			var parameters = new object[] {
	            new SqlParameter("@OpcionTraer", 2),
	            new SqlParameter("@LongIdentificacion", identificacion)
            };
			var result = _context.ConsultaDocenteValidados.FromSqlRaw("EXEC PA_OBTENER_DOCENTES_VALIDADOS @OpcionTraer, @LongIdentificacion", parameters).AsEnumerable().FirstOrDefault();

			return result;
		}

		public async Task<List<ConsultaDocenteValidado>> GetConsultaDocenteValidadosAsync()
		{
			var parametro = new SqlParameter("@OpcionTraer", 1);

			var result = await _context.ConsultaDocenteValidados.FromSqlRaw("EXEC PA_OBTENER_DOCENTES_VALIDADOS @OpcionTraer", parametro).ToListAsync();
			return result;
		}

		public async Task<Docente> GetFirstInfoAsync(long identificacion)
        {
            var docente = await _context.Docentes.Where(x => x.Identificacion == identificacion).FirstOrDefaultAsync();
            return docente;
        }

        public async Task SaveInfoAsync(Docente docente)
        {
            _context.Add(docente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Docente docente)
        {
            _context.Update(docente);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ValidateExistenceAsync(Docente docente)
        {
            var validateExistence = await _context.Docentes.AnyAsync(x => x.Identificacion == docente.Identificacion);
            return validateExistence;
        }
    }
}
