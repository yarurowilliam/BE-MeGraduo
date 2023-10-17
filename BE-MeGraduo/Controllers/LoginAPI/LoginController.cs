using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Services.LoginServices;
using BE_MeGraduo.Utils;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using BE_MeGraduo.Persistence;
using BE_MeGraduo.Services.UsuarioServices;
using BE_MeGraduo.Services.RolServices;

namespace BE_MeGraduo.Controllers.LoginAPI
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _loginService;
		private readonly IUsuarioService _usuarioService;
		private readonly IConfiguration _config;
		private readonly IRolService _rolService;

		public LoginController(ILoginService loginService, IConfiguration config, IUsuarioService usuarioService, IRolService rolService)
		{
			_loginService = loginService;
			_config = config;
			_usuarioService = usuarioService;
			_rolService = rolService;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Usuario usuario)
		{
			try
			{
				usuario.Password = Encriptar.EncriptarPassword(usuario.Password);
				var user = await _loginService.ValidateUserAsync(usuario);
				if (user == null)
				{
					return BadRequest(new { message = Constantes.PASSWORD_INCORRECTA });
				}
				string tokenString = JwtConfigurator.GetToken(user, _config);
				return Ok(new { token = tokenString });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpGet("GetRoles")]
		public async Task<IActionResult> GetRoles(long id)
		{
			try
			{
				var usuario = await _usuarioService.GetFirstUserInfoAsync(id);
				if (usuario == null)
				{
					string mensajeError = string.Format(Constantes.USUARIO_NO_EXISTE, id);
					return BadRequest(new { message = mensajeError });
				}
				var userRoles = await _loginService.ValidateRolAsync(usuario);
				if (userRoles.Count == 0)
				{
					return BadRequest(new { message = Constantes.USUARIO_SIN_ROLES });
				}

				return Ok(userRoles);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
