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

using static System.Runtime.InteropServices.JavaScript.JSType;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.Extensions;

namespace HireMeNow_WebApi.API.Job
{

	[ApiController]
	[Authorize(Roles = "JOB_SEEKER")]
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
		public async Task<IActionResult> GetAllSavedJobs([FromQuery] JobListParams param)
		{


			//var UserId = _authUserService.GetUserId();
			var savedJobs =await  _jobservice.GetAllSavedJobsOfSeeker(param);
			Response.AddPaginationHeader(savedJobs.CurrentPage, savedJobs.PageSize, savedJobs.TotalCount, savedJobs.TotalPages);

			
			if (savedJobs!=null)
			{
				return Ok(savedJobs);
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpGet]
		[Route("job-seeker/{jobseekerId}/savedjobs/{savedJobId}")]
		public ActionResult GetSavedJobs(Guid jobseekerId,Guid savedJobId)
		{
			//var UserId = new Guid("A52C61EA-F163-4EA1-6A69-08DBD2287DF5");
			SavedJob savedJob =  _jobservice.RemoveSavedJob(jobseekerId, savedJobId);
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
