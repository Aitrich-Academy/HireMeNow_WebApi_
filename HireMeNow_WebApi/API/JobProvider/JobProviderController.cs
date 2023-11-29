using AutoMapper;
using Domain.Models;
using Domain.Service.Job.DTOs;
using Domain.Service.Job;
using Domain.Service.Job.Interfaces;
using Domain.Service.JobProvider.Interfaces;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Service.JobProvider.DTOs;
using Microsoft.AspNetCore.Authorization;
using Domain.Service.JobSeeker;
using Domain.Service.SignUp.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Domain.Service.JobProvider;

namespace HireMeNow_WebApi.API.JobProvider
{
  /*  [Route("api/[controller]")]*/
    [ApiController]
    [Authorize(Roles = "JOB_PROVIDER")]

    public class JobProviderController : BaseApiController<JobProviderController>
    {
        private readonly IJobProviderService _jobProviderService;
        private readonly IMapper _mapper;
        IJobProviderRepository _jobRepository;

        public JobProviderController(IJobProviderService jobProviderService, IMapper mapper, IJobProviderRepository jobProviderRepository)
        {
            _jobProviderService = jobProviderService;
            _mapper = mapper;
            _jobRepository = jobProviderRepository;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("company/companyId")]
        public async Task<IActionResult> GetAllJobs(Guid companyId)
        {
            try
            {
                List<JobPost> jobposts = await _jobProviderService.GetJobs(companyId);
                return Ok(_mapper.Map<List<JobPostsDtos>>(jobposts));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("company/{companyId}/job-provider/{jobproviderId}/job")]
        public async Task<IActionResult> GetAllJobsByProvider(Guid companyId, Guid jobproviderId)
        {
            try
            {
                List<JobPost> jobposts = await _jobProviderService.GetAllJobsByProvider(companyId, jobproviderId);
                return Ok(_mapper.Map<List<JobPostsDtos>>(jobposts));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [AllowAnonymous]
        [HttpPost]
        [Route("company/{companyId}/job-provider/{jobproviderId}/job")]

        public async Task<IActionResult> PostJob(JobPostsDtos jobpostDto)
        {
            var job = _mapper.Map<JobPost>(jobpostDto);
            _jobProviderService.PostJob(job);
            return Ok(jobpostDto);

    }

        [AllowAnonymous]
        [HttpPut]
        [Route("company/{companyId}/job-provider/{jobproviderId}/job/{id}")]

        public async Task<IActionResult> UpdateJob(JobPostsDtos jobpostDto, Guid id)
        {
            try
            {
                jobpostDto.Id = id;
                var job = _mapper.Map<JobPost>(jobpostDto);
                _jobProviderService.Update(job);
                return Ok(_mapper.Map<JobPostsDtos>(job));
}
            catch(Exception ex)
            {
                return BadRequest();
            }
        }


        [AllowAnonymous]
        [HttpDelete]
        [Route("company/{companyId}/job-provider/{jobproviderId}/job/{id}")]

        public async Task<IActionResult> DeleteJob(Guid id)
        {
            try
            {
                _jobProviderService.DeleteJob(id);
                return NoContent();
    }
            catch (Exception ex)
            {
                return BadRequest();
}
        }

    }
}


