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

namespace HireMeNow_WebApi.API.JobProvider
{
  /*  [Route("api/[controller]")]*/
    [ApiController]
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
    }
}
