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
                return Ok(_mapper.Map<List<JobProviderDto>>(jobposts));
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
                return Ok(_mapper.Map<List<JobProviderDto>>(jobposts));
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


    }
}

/*{
    "id": "2E4329CE-455B-421D-F945-08DBD45838C9",
  "jobTitle": "JavaDeveloper",
  "jobSummary": "Mid-Level",
  "jobLocation": "2E4329CE-455B-421D-F945-07DBD45838C9",
  "company": "58F8C10F-59A9-4A0B-8C94-39D01C2565AC",
  "industry": "58F8C10F-59A9-4A0B-8C94-39D01C2565AC",
  "postedBy": "58F8C10F-59A9-4A0B-8C94-39D01C2565AC",
  "postedDate": "2023-10-28T04:26:27.626Z"
}*/

/*{
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "jobTitle": "Flutter",
  "jobSummary": "developer",
  "jobLocation": "B18A7C3C-62F8-490B-9FB8-7CFE49D09A6E",
  "company": "C9E968B8-0C11-4B11-9736-0CC9183F8E1C",
  "category": "64891B9B-12E2-4B4C-8A71-3A7A596A352F",
  "industry": "A5EC3040-31D2-4FB8-8EF4-7D93D857C86A",
  "postedBy": "58f8c10f-59a9-4a0b-8c94-39d01c2565ac",
  "postedDate": "2023-10-28T05:28:37.623Z"
}*/