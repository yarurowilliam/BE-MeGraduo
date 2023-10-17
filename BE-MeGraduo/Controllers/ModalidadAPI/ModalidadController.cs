using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence;
using BE_MeGraduo.Services.ModalidadServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BE_MeGraduo.Services.SubModalidadService;

namespace BE_MeGraduo.Controllers.ModalidadAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadController : Controller
    {
        private readonly IModalidadService _service;
        private readonly ISubModalidadService _subModalidadService;
        public ModalidadController(IModalidadService service, ISubModalidadService subModalidadService)
        {
            _service = service;
            _subModalidadService = subModalidadService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Modalidad modalidad)
        {
            try
            {
                var validateExistence = await _service.ValidateExistenceAsync(modalidad);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.MODALIDAD_YA_EXISTE, modalidad.NombreModalidad);
                    return BadRequest(new { message = mensajeError });
                }
                await _service.SaveAsync(modalidad);
                return Ok(new { message = Constantes.MODALIDAD_REGISTRADA });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("SubModalidad/GuardarSubModalidad")]
        [HttpPost]
        public async Task<IActionResult> PostSubModalidad([FromBody] SubModalidad subModalidad)
        {
            try
            {
                var validateExistence = await _subModalidadService.ValidateExistenceAsync(subModalidad);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.SUB_MODALIDAD_YA_EXISTE, subModalidad.NombreSubModalidad);
                    return BadRequest(new { message = mensajeError });
                }
                await _subModalidadService.SaveAsync(subModalidad);
                return Ok(new { message = Constantes.SUB_MODALIDAD_REGISTRADA });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListModalidades")]
        [HttpGet]
        public async Task<IActionResult> GetListModalidadesAsync()
        {
            try
            {
                var list = await _service.GetListAsync();
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_MODALIDAD });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("SubModalidad/GetListSubModalidades")]
        [HttpGet]
        public async Task<IActionResult> GetListSubModalidadesAsync()
        {
            try
            {
                var list = await _subModalidadService.GetListAsync();
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_SUB_MODALIDAD });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{nombreModalidad}")]
        public async Task<IActionResult> Delete(string nombreModalidad)
        {
            try
            {
                var modalidad = await _service.GetFirstInfoAsync(nombreModalidad);
                if (modalidad == null)
                {
                    string mensajeError = string.Format(Constantes.MODALIDAD_NO_EXISTE, nombreModalidad);
                    return BadRequest(new { message = mensajeError });
                }
                await _service.DeleteAsync(modalidad);
                return Ok(new { message = Constantes.MODALIDAD_ELIMINADO });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("SubModalidad/{nombreModalidad}")]
        public async Task<IActionResult> DeleteSub(string nombreSubModalidad)
        {
            try
            {
                var modalidad = await _subModalidadService.GetFirstInfoAsync(nombreSubModalidad);
                if (modalidad == null)
                {
                    string mensajeError = string.Format(Constantes.SUB_MODALIDAD_NO_EXISTE, nombreSubModalidad);
                    return BadRequest(new { message = mensajeError });
                }
                await _subModalidadService.DeleteAsync(modalidad);
                return Ok(new { message = Constantes.MODALIDAD_ELIMINADO });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{nombreModalidad}")]
        public async Task<IActionResult> Get(string nombreModalidad)
        {
            try
            {
                var modalidad = await _service.GetFirstInfoAsync(nombreModalidad);
                return Ok(modalidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("SubModalidad/{nombreModalidad}")]
        public async Task<IActionResult> GetSubModalidad(string nombreSubModalidad)
        {
            try
            {
                var modalidad = await _subModalidadService.GetFirstInfoAsync(nombreSubModalidad);
                return Ok(modalidad);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
