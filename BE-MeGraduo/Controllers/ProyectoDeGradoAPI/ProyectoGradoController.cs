using BE_MeGraduo.Services.DocenteServices;
using BE_MeGraduo.Services.EstudianteServices;
using BE_MeGraduo.Services.PersonaServices;
using BE_MeGraduo.Services.ProgramaServices;
using BE_MeGraduo.Services.UsuarioServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence;
using System.Drawing;
using BE_MeGraduo.Services.ProyectoDeGradoServices;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace BE_MeGraduo.Controllers.ProyectoDeGradoAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoGradoController : Controller
    {
        private readonly IPersonaService _service;
        private readonly IUsuarioService _usuarioService;
        private readonly IEstudianteService _estudianteService;
        private readonly IDocenteService _docenteService;
        private readonly IProgramaService _programaService;
        private readonly IProyectoGradoService _proyectoGradoService;

        public ProyectoGradoController(IPersonaService personaService,
            IUsuarioService usuarioService, 
            IEstudianteService estudianteService,
            IDocenteService docenteService, 
            IProgramaService programaService,
            IProyectoGradoService proyectoGradoService)
        {
            _service = personaService;
            _usuarioService = usuarioService;
            _estudianteService = estudianteService;
            _docenteService = docenteService;
            _programaService = programaService;
            _proyectoGradoService = proyectoGradoService;
        }

        [HttpPost("ValidarRequisitos")]
        public async Task<IActionResult> ValidarRequisitosAsync(long identificacion)
        {
            try
            {
                var validateExistence = await _estudianteService.GetFirstInfoAsync(identificacion);
                if (validateExistence == null)
                {
                    string mensajeError = string.Format(Constantes.ESTUDIANTE_NO_EXISTE, identificacion);
                    return BadRequest(new { message = mensajeError });
                }

                if (validateExistence.Modalidad != 0 || validateExistence.Estado != "SIN PROYECTO")
                {
                    return BadRequest(new { message = "No es posible iniciar una propuesta ya que usted no cumple con los requisitos..." });
                }

                if(validateExistence.CreditosAprobados == 0)
                {

                    return BadRequest(new { message = "No es posible iniciar una propuesta ya que usted no cumple con los requisitos de creditos, es posible que su cuenta aun no este verificado, comunique a un adiministrador para informar que su cuenta no tiene CreditosAprobados" });
                }

                var programa = await _programaService.GetFirstProgramadInfoByIDAsync(validateExistence.IdPrograma);

                double valorParcial = validateExistence.CreditosAprobados;
                double valorTotal = programa.NumeroCreditos;


                double porcentaje = ((valorParcial / valorTotal) * 100);

                if (porcentaje < 70)
                {
                    return BadRequest(new { message = $"No es posible iniciar una propuesta ya que usted no cumple con los requisitos de creditos aprobados. Es necesario tener mas del 70% y usted solo tiene {porcentaje}" });
                }

                return Ok(true);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadPdfFile([FromForm] IFormFile file)
        {
            try
            {
                var fileId = await _proyectoGradoService.AddFile(file);
                return Ok($"Archivo PDF subido exitosamente con ID: {fileId}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet("download/{id}")]
        public IActionResult DownloadPdfFile(int id)
        {
            var pdfFile = _proyectoGradoService.GetFile(id);

            if (pdfFile == null)
            {
                return NotFound(); // O puedes devolver un mensaje de error personalizado.
            }

            // Realiza la descarga del archivo.
            return File(pdfFile.Data, "application/pdf", pdfFile.FileName);
        }

        [HttpPost] ///WAITING FOR VALIDACIONES...
        public async Task<IActionResult> Post([FromBody] ProyectoGrado item)
        {
            try
            {
                var validateExistence = await _proyectoGradoService.ValidateExistenceAsync(item);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.PROYECTO_YA_EXISTE, item.Titulo);
                    return BadRequest(new { message = mensajeError });
                }
                item.Comentarios = new List<Comentario>();
                await _proyectoGradoService.SaveProyectoAsync(item);
                return Ok(new { message = Constantes.PROPUESTA_REGISTRADO });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("AddComentario")]
        [HttpPost] ///WAITING FOR VALIDACIONES...
        public async Task<IActionResult> AddComentario([FromBody] Comentario item)
        {
            try
            {
                var proyecto = await _proyectoGradoService.GetFirstInfoAsync(item.IdProyecto);
                if (proyecto == null)
                {
                    string mensajeError = string.Format(Constantes.PROYECTO_NO_EXISTE, item.IdProyecto);
                    return BadRequest(new { message = mensajeError });
                }

                // Comprobación por si la lista es nula
                if (proyecto.Comentarios == null)
                {
                    proyecto.Comentarios = new List<Comentario>();
                }

                // Añadir el comentario
                proyecto.Comentarios.Add(item);

                await _proyectoGradoService.UpdateAsync(proyecto);
                return Ok(new { message = Constantes.COMENTARIO_ADD });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListProyectosAll")]
        [HttpGet]
        public async Task<IActionResult> GetListProyectosAsync()
        {
            try
            {
                var list = await _proyectoGradoService.GetListAsync();
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_PROYECTO });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var proyecto = await _proyectoGradoService.GetFirstInfoAsync(id);
                return Ok(proyecto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetListProyectoByDirector/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetListProyectoByDirector(long id)
        {
            try
            {
                var list = await _proyectoGradoService.GetListByDirector(id);
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_PROYECTO_ASIGNADO });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListProyectoByJurado/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetListProyectoByJurado(long id)
        {
            try
            {
                var list = await _proyectoGradoService.GetListByJurado(id);
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_PROYECTO_ASIGNADO });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GetListProyectoByAsesor/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetListProyectoByAsesor(long id)
        {
            try
            {
                var list = await _proyectoGradoService.GetListByAsesor(id);
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_PROYECTO_ASIGNADO });
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
