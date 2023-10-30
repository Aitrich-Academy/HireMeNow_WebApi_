using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.Job.Interfaces;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg;
using HireMeNow_WebApi.API.Job.SavedJobObjects;

using static System.Runtime.InteropServices.JavaScript.JSType;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.Extensions;
using Domain.Service.Job.DTOs;
using Domain.Service.Job;

namespace HireMeNow_WebApi.API.Job
{

	[ApiController]
	//[Authorize(Roles = "JOB_SEEKER")]
	public class JobController : BaseApiController<JobController>
	{
		protected IJobServices _jobservice;
		protected IAuthUserService _authUserService;
		protected IMapper _mapper;
		

		public JobController(IJobServices jobservice,IMapper mapper)
		{
			_jobservice = jobservice;
			_mapper = mapper;
			
		}
		[HttpGet]
		[Route("job-seeker/{jobseekerId}/savedjobs")]
		public async Task<IActionResult> savedjobs(Guid jobseekerId, [FromQuery]JobListParams param)
		{


			//var UserId = _authUserService.GetUserId();
			var savedJobs =  await _jobservice.GetAllSavedJobsOfSeeker(jobseekerId, param);
			Response.AddPaginationHeader(savedJobs.CurrentPage, savedJobs.PageSize, savedJobs.TotalCount, savedJobs.TotalPages);
			//var savedjobObjects = _mapper.Map<PagedList<SavedJobsDtos>>(savedjobs);


			if (savedJobs!=null)
			{
				return Ok(savedJobs);
			}
			else
			{
				return BadRequest("Not Found");
			}
		}
		//[HttpGet]
		//[Route("job-seeker/{jobseekerId}/savedjobs/{savedJobId}")]
		//public ActionResult GetSavedJobs(Guid jobseekerId,Guid savedJobId)
		//{
			
		//	SavedJobsDtos savedJob =  _jobservice.GetsavedJobById(jobseekerId, savedJobId);
		//	if( savedJob!=null )
		//	{
		//	return Ok(savedJob);	
		//	}
		//	else
		//	{
		//		return NoContent();
		//	}
		//}
		[HttpDelete]
		[Route("job-seeker/{jobseekerId}/savedjobs/{savedJobId}")]
		public async Task<ActionResult> RemoveSavedJob(Guid jobseekerId, Guid savedJobId)
		{
			SavedJob savedJob = _jobservice.RemoveSavedJob(jobseekerId, savedJobId);
			if (savedJob != null)
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
