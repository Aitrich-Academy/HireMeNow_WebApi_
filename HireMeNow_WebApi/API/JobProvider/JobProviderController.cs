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

/*

{
  "id": "fcbfe9d3-69d4-4ae7-9ff3-9c4c23f9a3e1",
  "jobTitle": "Accountant",
  "jobSummary": "Accounts",
  "jobLocation": "b59b6678-4c51-47e3-a1e1-621be8e1e2b3",
  "company": "e0f91cc0-5eb6-4a7c-8a3c-21f590007bb2",
  "category": "73bf4561-8063-4c08-aec3-4153a08d1c9b",
  "industry": "9b13f2d6-78a1-4d12-9c8a-ec2333986ec5",
  "postedBy": "3f68208d-dc6f-4e5c-9c23-52aef066b35f",
  "postedDate": "2023-10-30T11:33:28.577Z"
}

{
  "id": "c8e35f20-76b7-48e3-af3e-9d7d2e35e8ce",
  "jobTitle": "dotNetDeveloper",
  "jobSummary": "Web-Dev",
  "jobLocation": "7d5c1f3a-8e0e-42a7-9b8f-5db7ae6c82a9",
  "company": "8d3f614b-6977-43b6-a1ef-8f2051c2e5c9",
  "category": "eebf0b8c-60a7-4c7e-a92c-0847b9c812f9",
  "industry": "6A62EC85-4F4E-4F5F-BDDA-6B7D72F38D94",
  "postedBy": "3f68208d-dc6f-4e5c-9c23-52aef066b35f",
  "postedDate": "2023-10-30T10:35:13.639Z"
}

 */