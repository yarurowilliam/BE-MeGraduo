﻿using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.DocenteRepositories
{
    public interface IDocenteRepository
    {
        Task SaveInfoAsync(Docente docente);
        Task<Docente> GetFirstInfoAsync(long identificacion);
        Task<bool> ValidateExistenceAsync(Docente docente);
        //Task<List<ConsultaEstudiante>> GetListAsync();
        Task UpdateAsync(Docente docente);
		Task<List<ConsultaDocenteValidado>> GetConsultaDocenteValidadosAsync();
        Task<ConsultaDocenteValidado> GetCompleteInfoDocenteAsync(long identificacion);
	}
}
