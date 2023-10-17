using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence;
using BE_MeGraduo.Services.SedeServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BE_MeGraduo.Services.FacultadServices;

namespace BE_MeGraduo.Controllers.FacultadAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultadController : Controller
    {
        private readonly IFacultadService _service;
        public FacultadController(IFacultadService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Facultad facultad)
        {
            try
            {
                var validateExistence = await _service.ValidateExistenceAsync(facultad);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.SEDE_YA_EXISTE, facultad.NombreFacultad);
                    return BadRequest(new { message = mensajeError });
                }
                await _service.SaveFacultadAsync(facultad);
                return Ok(new { message = Constantes.FACULTAD_REGISTRADA });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListFacultades")]
        [HttpGet]
        public async Task<IActionResult> GetListFacultadesAsync()
        {
            try
            {
                var list = await _service.GetListFacultadesAsync();
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_FACULTAD });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{nombreFacultades}")]
        public async Task<IActionResult> Delete(string nombreFacultad)
        {
            try
            {
                var rol = await _service.GetFirstFacultadInfoAsync(nombreFacultad);
                if (rol == null)
                {
                    string mensajeError = string.Format(Constantes.FACULTAD_NO_EXISTE, nombreFacultad);
                    return BadRequest(new { message = mensajeError });
                }
                await _service.DeleteFacultadAsync(rol);
                return Ok(new { message = Constantes.FACULTAD_ELIMINADO });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{nombreSede}")]
        public async Task<IActionResult> Get(string nombreFacultad)
        {
            try
            {
                var facultad = await _service.GetFirstFacultadInfoAsync(nombreFacultad);
                return Ok(facultad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
