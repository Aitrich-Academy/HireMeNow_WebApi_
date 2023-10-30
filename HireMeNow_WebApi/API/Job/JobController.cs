using AutoMapper;

using Domain.Models;
using Domain.Service.Job;
using Domain.Service.Job.DTOs;
using Domain.Service.Job.Interfaces;
using HireMeNow_WebApi.Controllers;
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
		
  private readonly IMapper _mapper;
 public JobController(IMapper mapper, IJobServices jobService, IJobRepository jobRepostory)
        {
            _mapper = mapper;
            _jobservice = jobService;
           
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
      [HttpGet]
        [Route("company/{companyId}/jobs/{jobId}")]

        public async Task<IActionResult> GetJobsById(Guid companyId, Guid jobId)
        {
            try
            {
                List<JobPost> jobposts = await _jobservice.GetJobsById(companyId,jobId);
                return Ok(_mapper.Map<List<JobPostsDtos>>(jobposts));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
         [HttpGet]
        [Route("jobs/{companyId}")]
     
        public async Task<IActionResult> GetJobsByCompany(Guid companyId)
        {
            try
            {
                List<JobPost> jobposts = await _jobservice.GetJobsByCompany(companyId);
                return Ok(_mapper.Map<List<JobPostsDtos>>(jobposts));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
          [HttpGet]
        [Route("jobs")]
        public async Task<IActionResult>  GetJob()
        {
            try
            {
                List<JobPost> jobposts = await _jobservice.GetJobs();
                return Ok(_mapper.Map<List<JobPostsDtos> >(jobposts));
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
       
        }
    }

	}


