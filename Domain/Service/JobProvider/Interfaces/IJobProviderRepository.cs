using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.Interfaces
{
    public interface IJobProviderRepository
    {
        public Task<List<JobPost>> GetJobs(Guid companyId);

        public Task<List<JobPost>> GetAllJobsByProvider(Guid companyId, Guid jobproviderId);
        
        public void Create(JobPost job);

        public Task<JobPost> UpdateAsync(JobPost Updatedjob);

        public Task<JobPost> GetJobById(Guid jobId);

        public void DeleteJob(Guid id);
    }
}
