using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.API.Job
{
	public class JobController : BaseApiController<JobController>
	{
		public IActionResult Index()
		{
			return BadRequest();
		}
	}
}
