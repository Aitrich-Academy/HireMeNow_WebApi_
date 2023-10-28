using AutoMapper;
using Domain.Service.Login.Interfaces;
using Domain.Service.SignUp.DTOs;
using Domain.Service.SignUp.Interfaces;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.API.JobSeeker
{
    //[Route("api/[controller]")]
    [ApiController]

    public class JobSeekerController : BaseApiController<JobSeekerController>
    {
        public ISignUpRequestService jobSeekerService { get; set; }

        public ILoginRequestService loginRequestService { get; set; }
        public IMapper mapper { get; set; }
        public JobSeekerController(ISignUpRequestService _jobSeekerService, IMapper _mapper,ILoginRequestService _loginRequestService) {
            jobSeekerService=_jobSeekerService;
            loginRequestService=_loginRequestService;
            mapper=_mapper;
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

    }
}
