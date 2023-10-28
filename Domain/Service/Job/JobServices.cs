using Domain.Models;
using Domain.Service.Job.Interfaces;
using Domain.Service.JobSeeker.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job
{
	public class JobServices:IJobServices
	{
        IJobRepository _jobRepository;
        public JobServices(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public async Task<List<JobPost>> GetJobs()
        {
            return await _jobRepository.GetJobs();
        }

        public async Task<List<JobPost>> GetJobsByCompany(Guid companyId)
        {
            return await _jobRepository.GetJobsByCompany(companyId);
        }

        public async Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId)
        {
            return await _jobRepository.GetJobsById(companyId,jobId);
        }
    }
}
