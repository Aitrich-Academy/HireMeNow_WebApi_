using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.Interfaces;
using Domain.Service.Login.Interfaces;
using Domain.Service.SignUp.DTOs;
using Domain.Service.SignUp.Interfaces;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using HireMeNow_WebApi.Controllers;
using HireMeNow_WebApi.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace HireMeNow_WebApi.API.JobSeeker
{
    //[Route("api/[controller]")]
    [ApiController]
	
        

	public class JobSeekerController : BaseApiController<JobSeekerController>
    {
        public ISignUpRequestService jobSeekerService { get; set; }

        public ILoginRequestService loginRequestService { get; set; }
        public IJobServices jobServices { get; set; }
        public IMapper mapper { get; set; }
        public JobSeekerController(ISignUpRequestService _jobSeekerService, IMapper _mapper,ILoginRequestService _loginRequestService,IJobServices _jobService) {
            jobSeekerService=_jobSeekerService;
            loginRequestService=_loginRequestService;
            mapper = _mapper;

			jobServices = _jobService;

        }
        [HttpPost]
        [Route("job-seeker/signup")]
        public async Task<ActionResult> createJobSeekerSignupRequest(JobSeekerSignupRequest data)
        {
           var jobSeekerSignupRequestDto= mapper.Map<JobSeekerSignupRequestDto>(data);
            jobSeekerService.CreateSignupRequest(jobSeekerSignupRequestDto);
            return Ok(data);
        }
        [HttpGet]
        [Route("job-seeker/signup/{jobSeekerSignupRequestId}/verify-email")]
        public async Task<ActionResult> VerifyJobSeekerEmail(Guid jobSeekerSignupRequestId)
        {
            var isVerified=await jobSeekerService.VerifyEmailAsync(jobSeekerSignupRequestId);
            if (isVerified)
            {
                return Ok("Verified");
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("job-seeker/signup/{jobSeekerSignupRequestId}/set-password")]
        public async Task<ActionResult> createJobSeekerSignupRequest(Guid jobSeekerSignupRequestId, [FromBody] string password)
        {
            //var jobSeekerSignupRequestDto = mapper.Map<JobSeekerSignupRequestDto>(data);
            await jobSeekerService.CreateJobseeker(jobSeekerSignupRequestId, password);
            return Ok();
        }

        [HttpPost]
        [Route("job-seeker/login")]
        public async Task<ActionResult> Login(JobSeekerLoginRequest logdata)
        {
            //var user = _mapper.Map<User>(userDto);
          var user = loginRequestService.login(logdata.Email, logdata.Password);
            
            if (user == null)
            {
                return BadRequest("Login Failed");
            }
            return Ok(user);
        }
        [HttpGet]
        [Route("job-seeker/{jobseekerId}/job-application")]
        public async Task<ActionResult> getAllJobApplicationsOfUser(Guid jobseekerId, [FromQuery] JobListParams param)
        {
            var appliedJobs = await jobServices.GetAllAppliedJobs(jobseekerId, param);
            Response.AddPaginationHeader(appliedJobs.CurrentPage, appliedJobs.PageSize, appliedJobs.TotalCount, appliedJobs.TotalPages);
            if (appliedJobs == null)
            {
                return BadRequest("No Applied Jobs");
            }
            return Ok(appliedJobs);
        }
        [HttpPost]
        [Route("job-seeker/{jobseekerId}/job-application/{JobId}")]
        public async Task<IActionResult> applyJob(Guid jobseekerId,Guid JobId,ApplyJobRequest applyjobRequest)
        {
            applyjobRequest.Applicant = jobseekerId;
            applyjobRequest.JobPost_id = JobId;
            var appliedJobs = mapper.Map<JobApplication>(applyjobRequest);
            var status = jobServices.ApplyJob(appliedJobs);
            if(status==true)
            {
                return Ok("JobsApplied Succesfully");
            }
            else
                {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("job-seeker/{jobseekerId}/job-application/{JobApplicationId}/cancel")]
        public async Task<ActionResult> CancelAppliedJob(Guid jobseekerId,Guid JobApplicationId)
        {
            var status=jobServices.CancelAppliedJob(jobseekerId, JobApplicationId);
            if(status==true)
            {
                return Ok("Successfully cancel the job");
            }
            else
            {
                return NotFound();  
            }
        }
    }
}
