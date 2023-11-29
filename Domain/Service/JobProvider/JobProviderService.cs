using Domain.Models;
using Domain.Service.Job;
using Domain.Service.Job.Interfaces;
using Domain.Service.JobProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
    public class JobProviderService:IJobProviderService
    {
        IJobProviderRepository _jobProviderRepository;
        public JobProviderService(IJobProviderRepository jobProviderRepository)
        {
            _jobProviderRepository = jobProviderRepository;
        }
        public async Task<List<JobPost>> GetJobs(Guid companyId)
        {
            return await _jobProviderRepository.GetJobs(companyId);
        }

        public async Task<List<JobPost>> GetAllJobsByProvider(Guid companyId, Guid jobproviderId)
        {
            return await _jobProviderRepository.GetAllJobsByProvider(companyId, jobproviderId);
        }

        public void PostJob(JobPost job)
        {
            _jobProviderRepository.Create(job);
        }

        public async Task<JobPost> GetJobById(Guid jobId)
        {
            return await _jobProviderRepository.GetJobById(jobId);
           
        }
        public async Task<JobPost> Update(JobPost job)
        {
            var updatedjob = await _jobProviderRepository.UpdateAsync(job);
            return updatedjob;
        }

        public void DeleteJob(Guid id)
        {
            _jobProviderRepository.DeleteJob(id);
        }
    }
}
