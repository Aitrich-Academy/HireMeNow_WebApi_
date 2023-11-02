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
        [Route("job-seeker/upload-resume")]
        public async Task<ActionResult> UploadResume(Guid jobSeekerId, Guid profileId, string profileName, string profileSummary, string title, IFormFile file)
        {
            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] fileData = memoryStream.ToArray();

            Guid resumeId = await jobSeekerService.addResume(title, fileData);

            await jobSeekerService.addResumeToProfile(profileId, resumeId, jobSeekerId, profileName, profileSummary);
            return Ok();
        }

        [HttpPut]
        [Route("job-seeker/update-resume")]
        public async Task<ActionResult> UpdateResume(Guid profileId,IFormFile file)
        {

            Guid resumeId = await jobSeekerService.getResumeId(profileId);

            var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            byte[] fileData = memoryStream.ToArray();

           await jobSeekerService.UpdateResume(resumeId, fileData);

           
            return Ok();
        }

        [HttpGet]
        [Route("job-seeker/getResume/{profileId}")]
        public async Task<ActionResult<byte[]>> GetResume(Guid profileId)
        {
            try
            {
                Guid resumeId = await jobSeekerService.getResumeId(profileId);

                byte[] byteArray = await jobSeekerService.getResumeFile(resumeId);

                if (byteArray == null)
                {
                    return NotFound(); // Or any appropriate status code if the file doesn't exist.
                }

                return byteArray;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("job-seeker/update-resume")]
        public async Task<ActionResult> DeleteResume(Guid profileId)
        {

            Guid resumeId = await jobSeekerService.getResumeId(profileId);

            await jobSeekerService.DeleteResume(resumeId);


            return Ok();
        }

    }
}
