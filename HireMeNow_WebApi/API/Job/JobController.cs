using Domain.Models;
using Domain.Service.Job.Interfaces;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.API.Job
{
	
	[ApiController]
	[Authorize(Roles = "JOBSEEKER")]
	public class JobController : BaseApiController<JobController>
	{
		protected IJobServices _jobservice;

		public JobController(IJobServices jobservice)
		{
			_jobservice = jobservice;
		}
		[HttpGet]
		[Route("job-seeker/savedjobs")]
		public async Task<ActionResult> GetAllSavedJobs(Guid jobSeekerId)
		{
			
			List<SavedJob> savedJobs = await _jobservice.GetAllSavedJobsOfSeeker(jobSeekerId);
			if(savedJobs!=null)
			{
				return Ok(savedJobs);
			}
			else
			{
				return BadRequest();
			}
		}
	}
}
