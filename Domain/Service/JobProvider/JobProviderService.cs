using Domain.Models;
using Domain.Service.Job.Interfaces;
using Domain.Service.JobProvider.Interfaces;
using System;
using System.Collections.Generic;
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
    }
}
