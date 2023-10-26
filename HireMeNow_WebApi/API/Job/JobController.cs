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


        public JobController(IMapper mapper, IJobServices jobService, IJobRepository jobRepostory)
        {
            _mapper = mapper;
            _jobService = jobService;
            _jobRepository = jobRepostory;
        }

        [HttpGet]
        [Route("jobs")]
        public async Task<IActionResult>  GetJob()
        {
            try
            {
                List<JobPost> jobposts = await _jobService.GetJobs();
                return Ok(_mapper.Map<List<JobPostsDtos> >(jobposts));
            }
            catch(Exception ex)
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
                List<JobPost> jobposts = await _jobService.GetJobsByCompany(companyId);
                return Ok(_mapper.Map<List<JobPostsDtos>>(jobposts));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("jobs/{companyId}/jobs/{jobid}")]

        public async Task<IActionResult> GetJobsById(Guid companyId, Guid jobId)
        {
            try
            {
                List<JobPost> jobposts = await _jobService.GetJobsById(companyId,jobId);
                return Ok(_mapper.Map<List<JobPostsDtos>>(jobposts));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
