using BE_MeGraduo.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace BE_MeGraduo.Utils
{
	public class JwtConfigurator
	{
		public static string GetToken(Usuario userInfo, IConfiguration config)
		{
			string SecretKey = config["Jwt:SecretKey"];
			string Issuer = config["Jwt:Issuer"];
			string Audience = config["Jwt:Audience"];

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, userInfo.Identificacion.ToString()),
				new Claim("idUsuario", userInfo.Identificacion.ToString()),
				new Claim(JwtRegisteredClaimNames.Sid, userInfo.Email),
				new Claim("emailUsuario", userInfo.Email)
			   };

			var token = new JwtSecurityToken(
				issuer: Issuer,
				audience: Audience,
				claims,
				expires: DateTime.Now.AddHours(1),
				signingCredentials: credentials
				);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public static int GetTokenIdUsuario(ClaimsIdentity identity)
		{
			if (identity != null)
			{
				IEnumerable<Claim> claims = identity.Claims;
				foreach (var claim in claims)
				{
					if (claim.Type == "idUsuario")
					{
						return int.Parse(claim.Value);
					}
				}
			}
			return 0;
		}
	}
}
