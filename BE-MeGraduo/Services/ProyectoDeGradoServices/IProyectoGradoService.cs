using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.DTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE_MeGraduo.Services.ProyectoDeGradoServices
{
    public interface IProyectoGradoService
    {
        Task<int> AddFile(IFormFile file);
        FileProyectosGrado GetFile(int id);
        Task SaveProyectoAsync(ProyectoGrado item);
        Task<ProyectoGrado> GetFirstInfoAsync(int idProyecto);
        Task<bool> ValidateExistenceAsync(ProyectoGrado item);
        Task<List<ProyectoGrado>> GetListAsync();
        Task UpdateAsync(ProyectoGrado item);
        Task DeleteAsync(ProyectoGrado item);
        Task<List<ProyectoGrado>> GetListByDirector(long id);
        Task<List<ProyectoGrado>> GetListByAsesor(long id);
        Task<List<ProyectoGrado>> GetListByJurado(long id);
    }
}
