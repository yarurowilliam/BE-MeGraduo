﻿using BE_MeGraduo.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Repositories.FacultadRepositories
{
    public interface IFacultadRepository
    {
        Task SaveFacultadAsync(Facultad item);
        Task<Facultad> GetFirstFacultadInfoAsync(string nombreFacultad);
        Task<bool> ValidateExistenceAsync(Facultad item);
        Task<List<Facultad>> GetListFacultadesAsync();
        Task UpdateFacultadAsync(Facultad item);
        Task DeleteFacultadAsync(Facultad item);
    }
}
