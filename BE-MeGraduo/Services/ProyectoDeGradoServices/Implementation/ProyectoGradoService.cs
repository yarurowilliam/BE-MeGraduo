using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.ProyectoDeGradoRepositories;
using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BE_MeGraduo.Services.ProyectoDeGradoServices.Implementation
{
    public class ProyectoGradoService : IProyectoGradoService
    {
        private readonly IProyectoGradoRepository _proyectoGradoRepository;

        public ProyectoGradoService(IProyectoGradoRepository repository)
        {
            _proyectoGradoRepository = repository;
        }

        public async Task<int> AddFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("No se ha proporcionado un archivo válido.");
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);

                var pdfFile = new FileProyectosGrado
                {
                    IdProyecto = 1,
                    FileName = file.FileName,
                    Data = stream.ToArray()
                };

                return await _proyectoGradoRepository.AddFile(pdfFile);
            }
        }

        public async Task DeleteAsync(ProyectoGrado item)
        {
            await _proyectoGradoRepository.DeleteAsync(item);
        }

        public FileProyectosGrado GetFile(int id)
        {
            return _proyectoGradoRepository.GetFile(id);
        }

        public async Task<ProyectoGrado> GetFirstInfoAsync(int idProyecto)
        {
            return await _proyectoGradoRepository.GetFirstInfoAsync(idProyecto);
        }

        public async Task<List<ProyectoGrado>> GetListAsync()
        {
            return await _proyectoGradoRepository.GetListAsync();
        }

        public async Task<List<ProyectoGrado>> GetListByAsesor(long id)
        {
            return await _proyectoGradoRepository.GetListByAsesor(id);
        }

        public async Task<List<ProyectoGrado>> GetListByDirector(long id)
        {
            return await _proyectoGradoRepository.GetListByDirector(id);
        }

        public async Task<List<ProyectoGrado>> GetListByJurado(long id)
        {
            return await _proyectoGradoRepository.GetListByJurado(id);
        }

        public async Task SaveProyectoAsync(ProyectoGrado item)
        {
            await _proyectoGradoRepository.SaveProyectoAsync(item);
        }

        public async Task UpdateAsync(ProyectoGrado item)
        {
            await _proyectoGradoRepository.UpdateAsync(item);
        }

        public async Task<bool> ValidateExistenceAsync(ProyectoGrado item)
        {
            return await _proyectoGradoRepository.ValidateExistenceAsync(item);
        }
    }
}
