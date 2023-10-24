using AutoMapper;
using Domain.Models;
using Domain.Service.Job;
using Domain.Service.Job.DTOs;
using Domain.Service.Job.Interfaces;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.API.Job
{
   /* [Route("api/[controller]")]*/
    [ApiController]
    public class JobController : BaseApiController<JobController>
    {
        private readonly IJobServices _jobService;
        private readonly IMapper _mapper;
        IJobRepository _jobRepository;

        private IMapper mapper;

        [HttpGet]
        [Route("jobs")]
        public async Task<IActionResult>  GetJob()
        {
           List<JobPost>  jobposts = await _jobService.GetJobs();
           return Ok(_mapper.Map<JobPostsDtos>(jobposts));
        }
    }
}
