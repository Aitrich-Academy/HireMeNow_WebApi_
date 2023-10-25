using Domain.Helpers;
using Domain.Models;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.Job.Interfaces;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using PagedList;

namespace HireMeNow_WebApi.API.Job
{
	
	[ApiController]
	//[Authorize(Roles = "JOBSEEKER")]
	public class JobController : BaseApiController<JobController>
	{
		protected IJobServices _jobservice;
		protected IAuthUserService _authUserService;

		public JobController(IJobServices jobservice)
		{
			_jobservice = jobservice;
		}
		[HttpGet]
		[Route("job-seeker/savedjobs")]
		public async Task<ActionResult> GetAllSavedJobs([FromQuery] JobListParams param)
		{
			
			
			//var UserId = _authUserService.GetUserId();
			var savedJobs = _jobservice.GetAllSavedJobsOfSeeker(param);
			if(savedJobs!=null)
			{
				return Ok(savedJobs);
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpGet]
		[Route("job-seeker/savedjobs/{jobid}")]
		public ActionResult GetSavedJobs(Guid jobid)
		{
			var UserId = new Guid("A52C61EA-F163-4EA1-6A69-08DBD2287DF5");
			SavedJob savedJob =  _jobservice.RemoveSavedJob(UserId,jobid);
			if( savedJob!=null )
			{
			return Ok("Deleted");	
			}
			else
			{
				return NoContent();
			}
		}

	}
}
