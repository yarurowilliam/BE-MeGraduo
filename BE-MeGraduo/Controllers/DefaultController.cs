using Microsoft.AspNetCore.Mvc;

namespace BE_MeGraduo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DefaultController : Controller
	{
		[HttpGet]
		public string Get()
		{
			return "Aplicacion corriendo";
		}
	}
}
