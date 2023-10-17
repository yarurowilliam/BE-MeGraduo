using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence;
using BE_MeGraduo.Services.ProgramaServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace BE_MeGraduo.Controllers.ProgramaAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramaController : Controller
    {
        private readonly IProgramaService _service;
        public ProgramaController(IProgramaService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Programa programa)
        {
            try
            {
                var validateExistence = await _service.ValidateExistenceAsync(programa);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.PROGRAMA_YA_EXISTE, programa.NombrePrograma);
                    return BadRequest(new { message = mensajeError });
                }
                await _service.SaveProgramaAsync(programa);
                return Ok(new { message = Constantes.PROGRAMA_REGISTRADA });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListProgramas")]
        [HttpGet]
        public async Task<IActionResult> GetListProgramasAsync()
        {
            try
            {
                var list = await _service.GetListProgramasAsync();
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_PROGRAMA });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{nombrePrograma}")]
        public async Task<IActionResult> Delete(string nombrePrograma)
        {
            try
            {
                var programa = await _service.GetFirstProgramadInfoAsync(nombrePrograma);
                if (programa == null)
                {
                    string mensajeError = string.Format(Constantes.PROGRAMA_NO_EXISTE, nombrePrograma);
                    return BadRequest(new { message = mensajeError });
                }
                await _service.DeleteProgramaAsync(programa);
                return Ok(new { message = Constantes.PROGRAMA_ELIMINADO });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{nombrePrograma}")]
        public async Task<IActionResult> Get(string nombrePrograma)
        {
            try
            {
                var programa = await _service.GetFirstProgramadInfoAsync(nombrePrograma);
                return Ok(programa);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
