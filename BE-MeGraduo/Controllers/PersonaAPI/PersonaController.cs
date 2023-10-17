using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence;
using BE_MeGraduo.Services.PersonaServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BE_MeGraduo.Services.UsuarioServices;
using BE_MeGraduo.Services.EstudianteServices;
using BE_MeGraduo.Services.DocenteServices;

namespace BE_MeGraduo.Controllers.PersonaAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : Controller
    {
        private readonly IPersonaService _service;
        private readonly IUsuarioService _usuarioService;
        private readonly IEstudianteService _estudianteService;
        private readonly IDocenteService _docenteService;

        public PersonaController(IPersonaService personaService, IUsuarioService usuarioService, IEstudianteService estudianteService, IDocenteService docenteService )
        {
            _service = personaService;
            _usuarioService = usuarioService;
            _estudianteService = estudianteService;
            _docenteService = docenteService;
        }

        [Route("GuardarInfoEstudiante")]
        [HttpPost]
        public async Task<IActionResult> PostEstudiante([FromBody] Estudiante estudiante)
        {
            try
            {
                var validateExistence = await _estudianteService.ValidateExistenceAsync(estudiante);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.ESTUDIANTE_YA_TIENE_INFORMACION, estudiante.Identificacion);
                    return BadRequest(new { message = mensajeError });
                }
                estudiante.Modalidad = 0;
                estudiante.SubModalidad = 0;    
                estudiante.Estado = "SIN PROYECTO";
                estudiante.TieneProyecto = false;
                await _estudianteService.SaveInfoAsync(estudiante);
                return Ok(new { message = Constantes.INFORMACION_COMPLETADA_ESTUDIANTE });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("GuardarInfoDocenteDefault")]
        [HttpPost]
        public async Task<IActionResult> PostDocenteDefault([FromBody] Docente docente)
        {
            try
            {
                var validateExistence = await _docenteService.ValidateExistenceAsync(docente);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.DOCENTE_YA_TIENE_INFORMACION, docente.Identificacion);
                    return BadRequest(new { message = mensajeError });
                }
                docente.Estado = "ACTIVO";
                await _docenteService.SaveInfoAsync(docente);
                return Ok(new { message = Constantes.INFORMACION_COMPLETADA_DOCENTE });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("TraerInfoPersonaEstudiante/{identificacion}")]
        public async Task<IActionResult> Get(long identificacion)
        {
            try
            {
                var persona = await _service.GetFirstInfoAsync(identificacion);
                var estudiante = await _estudianteService.GetFirstInfoAsync(identificacion);
                EstudianteInfo estudianteInfo = new EstudianteInfo
                {
                    Identificacion = identificacion,
                    PrimerNombre = persona.PrimerNombre,
                    SegundoNombre = persona.SegundoNombre,
                    PrimerApellido = persona.PrimerApellido,
                    SegundoApellido = persona.SegundoApellido,
                    Telefono = persona.Telefono,
                    Email = persona.Email,
                    Direccion = persona.Direccion,
                    CreditosAprobados = estudiante.CreditosAprobados,
                    TieneProyecto = estudiante.TieneProyecto,
                    Modalidad = estudiante.Modalidad,
                    SubModalidad = estudiante.SubModalidad,
                    IdPrograma = estudiante.IdPrograma,
                    Estado = estudiante.Estado
                };
                return Ok(estudianteInfo);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("TraerEstudiantesValidos/{identificacion}")]
        public async Task<IActionResult> GetValidStudents(long identificacion)
        {
            try
            {
                var estudiantes = await _estudianteService.GetEstudiantesValidadosAsync(identificacion);
                return Ok(estudiantes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		[HttpGet("TraerFullInfoDocente/{identificacion}")]
		public async Task<IActionResult> GetFullInfoDocente(long identificacion)
		{
			try
			{
				var docente = await _docenteService.GetCompleteInfoDocenteAsync(identificacion);
				return Ok(docente);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[HttpGet("TraerDocentes")]
		public async Task<IActionResult> GetValidDocentes()
		{
			try
			{
				var docentes = await _docenteService.GetConsultaDocenteValidadosAsync();
				return Ok(docentes);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

		[Route("GuardarInfoPersona")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Persona persona)
        {
            try
            {
                var usuario = await _usuarioService.GetFirstUserInfoAsync(persona.Identificacion);
                if (usuario == null)
                {
                    string mensajeError = string.Format(Constantes.USUARIO_NO_EXISTE, persona.Identificacion);
                    return BadRequest(new { message = mensajeError });
                }

                if(usuario.EstadoUsuario == Constantes.ESTADO_DEFAULT_USER)
                {
                    string mensajeError = string.Format(Constantes.VALIDE_SU_EMAIL, persona.Identificacion);
                    return BadRequest(new { message = mensajeError });
                }

                var validateExistence = await _service.ValidateExistenceAsync(persona);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.PERSONA_YA_EXISTE, persona.Identificacion);
                    return BadRequest(new { message = mensajeError });
                }
                var mensaje = "";
                if (usuario.RolDefault == "ESTUDIANTE")
                {
                    var student = await _estudianteService.GetFirstInfoAsync(persona.Identificacion);
                    if (student != null)
                    {
                        string mensajeError = string.Format(Constantes.ESTUDIANTE_YA_TIENE_INFORMACION, persona.Identificacion);
                        return BadRequest(new { message = mensajeError });
                    }
                    mensaje = "Hola Estudiante!\n\nGracias por completar tu informacion personal.\n\nIMPORTANTE: Tu cuenta se encuentra en etapa de verificacion y no podras escoger una modalidad de grado mientras la verifican.\n\nMeGraduoERP";
                   
                }

                if (usuario.RolDefault == "DOCENTE")
                {
                    var docente = await _docenteService.GetFirstInfoAsync(persona.Identificacion);
                    if (docente != null)
                    {
                        string mensajeError = string.Format(Constantes.DOCENTE_YA_TIENE_INFORMACION, persona.Identificacion);
                        return BadRequest(new { message = mensajeError });
                    }
                    mensaje = "Hola Docente!\n\nGracias por completar tu informacion personal.\n\nIMPORTANTE: Tu cuenta se encuentra en etapa de verificacion y no podras ser asignado como director, calificador o jurado.\n\nMeGraduoERP";
                   
                }

                var resultadoMail = await _usuarioService.SendMailAsync(usuario.Identificacion, usuario.Email, "Verificar Email", mensaje);

                if (resultadoMail)
                {
                    usuario.EstadoUsuario = Constantes.PENDIENTE_VERIFICACION;
                    await _service.SaveInfoAsync(persona);
                    await _usuarioService.ValidateEmailAsync(usuario);
                    return Ok(new { message = Constantes.COMPLETO_INFO_PERSONA });
                }
                else
                {
                    return BadRequest(new { message = "Hay un problema en la notificacion del correo, no fue posible actualizar su infomarcion personal." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
