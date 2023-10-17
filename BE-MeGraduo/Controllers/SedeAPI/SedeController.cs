using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence;
using BE_MeGraduo.Services.RolServices;
using BE_MeGraduo.Services.RolServices.Implementation;
using BE_MeGraduo.Services.SedeServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace BE_MeGraduo.Controllers.SedeAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class SedeController : Controller
    {
        private readonly ISedeService _service;
        public SedeController(ISedeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Sede sede)
        {
            try
            {
                var validateExistence = await _service.ValidateExistenceAsync(sede);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.SEDE_YA_EXISTE, sede.NombreSede);
                    return BadRequest(new { message = mensajeError });
                }
                await _service.SaveSedeAsync(sede);
                return Ok(new { message = Constantes.SEDE_REGISTRADA });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListSedes")]
        [HttpGet]
        public async Task<IActionResult> GetListSedesAsync()
        {
            try
            {
                var list = await _service.GetListSedesAsync();
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_SEDES });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{nombreSede}")]
        public async Task<IActionResult> Delete(string nombreSede)
        {
            try
            {
                var rol = await _service.GetFirstSedeInfoAsync(nombreSede);
                if (rol == null)
                {
                    string mensajeError = string.Format(Constantes.SEDE_NO_EXISTE, nombreSede);
                    return BadRequest(new { message = mensajeError });
                }
                await _service.DeleteSedeAsync(rol);
                return Ok(new { message = Constantes.SEDE_ELIMINADO });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{nombreSede}")]
        public async Task<IActionResult> Get(string nombreSede)
        {
            try
            {
                var sede = await _service.GetFirstSedeInfoAsync(nombreSede);
                return Ok(sede);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
