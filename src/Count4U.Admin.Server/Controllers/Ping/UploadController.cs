using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace Count4U.Local.Controllers
{
	[Route("[controller]")]
	[ApiController]
	public class UploadController : ControllerBase
	{
		private readonly IWebHostEnvironment environment;
		public UploadController(IWebHostEnvironment environment)
		{
			this.environment = environment;
		}

		//Работает
		[HttpPost]
		public async Task Post()
		{
			if (this.HttpContext.Request.Form.Files.Any())
			{
				foreach (var file in this.HttpContext.Request.Form.Files)
				{
					var path = Path.Combine("C:", "uploads", file.FileName); //environment.ContentRootPath
					using (var stream = new FileStream(path, FileMode.Create))
					{
						await file.CopyToAsync(stream);
					}
				}
			}
		}
	}
}

