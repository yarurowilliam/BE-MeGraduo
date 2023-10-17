using BE_MeGraduo.Services.RolServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Persistence;

namespace BE_MeGraduo.Controllers.RolAPI
{
	[Route("api/[controller]")]
	[ApiController]
	//[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class RolController : Controller
	{
		private readonly IRolService _rolService;
		public RolController(IRolService rolService)
		{
			_rolService = rolService;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Rol rol)
		{
			try
			{
				var validateExistence = await _rolService.ValidateExistenceAsync(rol);
				if (validateExistence)
				{
					string mensajeError = string.Format(Constantes.ROL_YA_EXISTE, rol.NombreRol);
					return BadRequest(new { message = mensajeError });
				}
				await _rolService.SaveRolAsync(rol);
				return Ok(new { message = Constantes.ROL_REGISTRADO});
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[Route("GetListRoles")]
		[HttpGet]
		public async Task<IActionResult> GetListRoles()
		{
			try
			{
				var listRoles = await _rolService.GetListRolesAsync();
				if (listRoles.Count == 0)
				{
					return BadRequest(new { message = Constantes.NO_HAY_ROLES });
				}
				return Ok(listRoles);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("{nombreRol}")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
		public async Task<IActionResult> Delete(string nombreRol)
		{
			try
			{
				var rol = await _rolService.GetFirstRolInfoAsync(nombreRol);
				if (rol == null)
				{
					string mensajeError = string.Format(Constantes.ROL_NO_EXISTE, nombreRol);
					return BadRequest(new { message = mensajeError });
				}
				await _rolService.DeleteRolAsync(rol);
				return Ok(new { message = Constantes.ROL_ELIMINADO });
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpPut("{nombreRol}")] //Desactivado
		public async Task<IActionResult> UpdateRol(string nombreRol, Rol item)
		{
			if (nombreRol != item.NombreRol)
			{
				string mensajeError = string.Format(Constantes.ROL_NO_EXISTE, nombreRol);
				return BadRequest(new { message = mensajeError });
			}
			var rol = await _rolService.GetFirstRolInfoAsync(nombreRol);
			if (rol != null)
			{
				string mensajeError = string.Format(Constantes.ROL_YA_EXISTE, nombreRol);
				return BadRequest(new { message = mensajeError });
			}

			await _rolService.UpdateRolAsync(item);
			return Ok(new { message = Constantes.ROL_ACTUALIZADO });
		}

		[HttpGet("{nombreRol}")]
		public async Task<IActionResult> Get(string nombreRol)
		{
			try
			{
				var rol = await _rolService.GetFirstRolInfoAsync(nombreRol);
				return Ok(rol);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}

	}
}
