using BE_MeGraduo.Services.UsuarioServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence;
using BE_MeGraduo.Utils;
using BE_MeGraduo.Services.UsuarioRolServices;
using BE_MeGraduo.Services.RolServices;

namespace BE_MeGraduo.Controllers.UsuarioAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRolService _usuarioRolService;
        private readonly IRolService _rolService;
        public UsuarioController(IUsuarioService usuarioService, IUsuarioRolService usuarioRolService, IRolService rolService)
        {
            _usuarioService = usuarioService;
            _usuarioRolService = usuarioRolService;
            _rolService = rolService;
        }

        [HttpPost("RetirarRol")]
        public async Task<IActionResult> RetirarRolAsync(long identificacion, string nombreRol)
        {
            try
            {
                var user = await _usuarioService.GetFirstUserInfoAsync(identificacion);
                if (user == null)
                {
                    string mensajeError = string.Format(Constantes.USUARIO_NO_EXISTE, identificacion);
                    return BadRequest(new { message = mensajeError });
                }
                var rol = await _rolService.GetFirstRolInfoAsync(nombreRol.ToUpper());
                if (rol == null)
                {
                    string mensajeError = string.Format(Constantes.ROL_NO_EXISTE, nombreRol);
                    return BadRequest(new { message = mensajeError });
                }

                var userRol = await _usuarioRolService.GetFirstAsinacionRolInfoAsync(user.Identificacion, rol.Id);
                if (userRol == null)
                {
                    return BadRequest(new { message = Constantes.ASIGNACION_NOEXISTE });
                }
                await _usuarioRolService.RetirarRolAsync(userRol);

                return Ok(new { message = Constantes.ROL_RETIRADO_CORRECTAMENTE });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("AsignarRol")]
        public async Task<IActionResult> AsignarRolesAsync(long identificacion, string nombreRol)
        {
            try
            {
                var user = await _usuarioService.GetFirstUserInfoAsync(identificacion);
                if (user == null)
                {
                    string mensajeError = string.Format(Constantes.USUARIO_NO_EXISTE, identificacion);
                    return BadRequest(new { message = mensajeError });
                }
                var rol = await _rolService.GetFirstRolInfoAsync(nombreRol.ToUpper());
                if (rol == null)
                {
                    string mensajeError = string.Format(Constantes.ROL_NO_EXISTE, nombreRol);
                    return BadRequest(new { message = mensajeError });
                }

                UsuarioRol usuarioRol = new UsuarioRol
                {
                    UsuarioIdentificacion = identificacion,
                    RolId = rol.Id
                };

                var validateExistence = await _usuarioRolService.ValidarRolExistenteAsync(usuarioRol);
                if (validateExistence)
                {
                    return BadRequest(new { message = Constantes.ROL_CON_USUARIO_YA_EXISTE });
                }
                await _usuarioRolService.AsignarRolesAsync(usuarioRol);

                return Ok(new { message = Constantes.ROL_ASIGNADO_CORRECTO });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GuardarUsuarioAsync([FromBody] Usuario usuario)
        {
            try
            {
                var validateExistence = await _usuarioService.ValidateExistenceAsync(usuario);
                if (validateExistence)
                {
                    string mensajeError = string.Format(Constantes.USUARIO_YA_EXISTE, usuario.Identificacion, usuario.Email);
                    return BadRequest(new { message = mensajeError });
                }
                usuario.Email = usuario.Email.ToUpper();
                usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
                usuario.EstadoUsuario = Constantes.ESTADO_DEFAULT_USER;
                var mensaje = "";
                UsuarioRol usuarioRol = null;
                try
                {
                    Rol rol = null;

                    if (usuario.RolDefault == "DOCENTE")
                    {
                        rol = await _rolService.GetFirstRolInfoAsync("DOCENTE");
                        mensaje = "Hola Docente!\nUsted debe confirmar su correo electronico, abra este link: https://localhost:44379/api/Usuario/ConfirmarEmail/" + usuario.Identificacion + " para confirmar su cuenta.";
                    }
                    else
                    {
                        rol = await _rolService.GetFirstRolInfoAsync("ESTUDIANTE");
                        mensaje = "Hola Estudiante!\nUsted debe confirmar su correo electronico, abra este link: https://localhost:44379/api/Usuario/ConfirmarEmail/" + usuario.Identificacion + " para confirmar su cuenta.";
                    }

                    usuarioRol = new UsuarioRol
                    {
                        RolId = rol.Id,
                        UsuarioIdentificacion = usuario.Identificacion
                    };

                }
                catch { }

                var resultadoMail = await _usuarioService.SendMailAsync(usuario.Identificacion, usuario.Email, "Verificar Email", mensaje);

                if (resultadoMail)
                {
                    await _usuarioService.SaveUserAsync(usuario);
                    await _usuarioRolService.AsignarRolesAsync(usuarioRol);


                    return Ok(new { message = Constantes.USUARIO_REGISTRADO });
                }
                else
                {
                    return BadRequest(new { message = "Hay un problema en la notificacion del correo, no fue posible crear su cuenta." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("ConfirmarEmail/{id}")]
        public async Task<IActionResult> ConfirmarEmailAsync(long id)
        {
            try
            {
                var usuario = await _usuarioService.GetFirstUserInfoAsync(id);
                if (usuario == null)
                {
                    string mensajeError = string.Format(Constantes.USUARIO_NO_EXISTE, id);
                    return BadRequest(new { message = mensajeError });
                }

                if (usuario.EstadoUsuario != Constantes.ESTADO_DEFAULT_USER)
                {
                    string mensajeError = string.Format(Constantes.USUARIO_YA_FUE_CONFIRMADO, id);
                    return BadRequest(new { message = mensajeError });
                }
                else
                {
                    usuario.EstadoUsuario = Constantes.ESTADO_COMPLETAR_INFORMACION;
                    await _usuarioService.ValidateEmailAsync(usuario);
                    return Ok(new { message = Constantes.CORREO_CONFIRMADO });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("VerificadoTotal/{id}")]
        public async Task<IActionResult> VerificadoTotal(long id)
        {
            try
            {
                var usuario = await _usuarioService.GetFirstUserInfoAsync(id);
                if (usuario == null)
                {
                    string mensajeError = string.Format(Constantes.USUARIO_NO_EXISTE, id);
                    return BadRequest(new { message = mensajeError });
                }
                if (usuario.EstadoUsuario == Constantes.ESTADO_DEFAULT_USER)
                {
                    string mensajeError = string.Format(Constantes.PENDIENTE_CONFIRMAR_MAIL, id);
                    var mensaje = "Hola upecista, aun no confirmas tu correo ELECTRONICO ingresa a este link: https://localhost:44379/api/Usuario/ConfirmarEmail/" + usuario.Identificacion + " para confirmar su cuenta.";
                    var resultadoMail = await _usuarioService.SendMailAsync(usuario.Identificacion, usuario.Email, "Oye! Confirma tu correo electronico", mensaje);
                    return BadRequest(new { message = mensajeError });
                }
                if (usuario.EstadoUsuario == Constantes.ESTADO_COMPLETAR_INFORMACION)
                {
                    string mensajeError = string.Format(Constantes.PENDIENTE_LLENAR_INFO, id);
                    var mensaje = "Hola, recuerda que debes completar tu informacion para disfrutar de los servicios de MeGraduo..ATT: MeGraduoERP";
                    var resultadoMail = await _usuarioService.SendMailAsync(usuario.Identificacion, usuario.Email, "Oye! Completa tu perfil", mensaje);
                    return BadRequest(new { message = mensajeError });
                }
                if (usuario.EstadoUsuario == Constantes.VERIFICACION_TOTAL)
                {
                    string mensajeError = string.Format(Constantes.USUARIO_YA_FUE_CONFIRMADO, id);
                    return BadRequest(new { message = mensajeError });
                }
                else
                {
                    usuario.EstadoUsuario = Constantes.VERIFICACION_TOTAL;

                    var mensaje = "Hola, tu cuenta fue verificada por un administrador, ya puedes iniciar normalmente en el sistema..ATT: MeGraduoERP";
                    var resultadoMail = await _usuarioService.SendMailAsync(usuario.Identificacion, usuario.Email, "Cuenta Verificada!", mensaje);

                    if (resultadoMail)
                    {
                        await _usuarioService.ValidateEmailAsync(usuario);
                        return Ok(new { message = Constantes.CUENTA_VERIFICADA });
                    }
                    else
                    {
                        return BadRequest(new { message = "Hay un problema en la notificacion del correo, no fue posible verificar la cuenta." });
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("VerificarUsuario/{identificacion}")]
        public async Task<IActionResult> Get(long identificacion)
        {
            try
            {
                var usuario = await _usuarioService.GetFirstUserInfoAsync(identificacion);
                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("GetListUsuarios")]
        [HttpGet]
        public async Task<IActionResult> GetListUsuariosAsync()
        {
            try
            {
                var list = await _usuarioService.GetListAsync();
                if (list.Count == 0)
                {
                    return BadRequest(new { message = Constantes.NO_HAY_USERS });
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
