using BE_MeGraduo.Domain.Models;
using BE_MeGraduo.Repositories.UsuarioRepositories;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BE_MeGraduo.Services.UsuarioServices.Implementation
{
	public class UsuarioService : IUsuarioService
	{
		private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
			_usuarioRepository = usuarioRepository;
        }

		public async Task<Usuario> GetFirstUserInfoAsync(long identificacion)
		{
			return await _usuarioRepository.GetFirstUserInfoAsync(identificacion);
		}

		public async Task SaveUserAsync(Usuario usuario)
		{
			await _usuarioRepository.SaveUserAsync(usuario);
		}

		public async Task UpdatePasswordAsync(Usuario usuario)
		{
			await _usuarioRepository.UpdatePasswordAsync(usuario);
		}

		public async Task ValidateEmailAsync(Usuario usuario)
		{
			await _usuarioRepository.ValidateEmailAsync(usuario);
		}

		public async Task<bool> ValidateExistenceAsync(Usuario usuario)
		{
			return await _usuarioRepository.ValidateExistenceAsync(usuario);
		}

		public async Task<Usuario> ValidatePasswordAsync(long identificacion, string passwordAnterior)
		{
			return await _usuarioRepository.ValidatePasswordAsync(identificacion, passwordAnterior);
		}

		public async Task<bool> SendMailAsync(long identificacion, string email, string asunto, string mensaje)
		{
			var result = true;
			try
			{
				var correo = new MailMessage
				{
					From = new MailAddress(email, "Notificaciones Me Graduo"),
					Subject = asunto,
					Body = mensaje,
					IsBodyHtml = true
				};

				correo.To.Add(email);

				using (var clienteSmtp = new SmtpClient("smtp.gmail.com"))
				{
					clienteSmtp.Port = 587;
					clienteSmtp.Credentials = new NetworkCredential("notificacionesmegraduo@gmail.com", "gsgbszxiyapcxqld");
					clienteSmtp.EnableSsl = true;

					await clienteSmtp.SendMailAsync(correo);
				}

				return result;
			}
			catch
			{
				result = false;
				return result;
			}
		}

        public async Task<List<Usuario>> GetListAsync()
        {
			return await _usuarioRepository.GetListAsync();
		}
    }
}
