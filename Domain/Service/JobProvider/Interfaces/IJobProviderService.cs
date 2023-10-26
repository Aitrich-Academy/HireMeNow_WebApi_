using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.Interfaces
{
    public interface IJobProviderService
    {
        public Task<List<JobPost>> GetJobs(Guid companyId);

        public Task<List<JobPost>> GetAllJobsByProvider(Guid companyId, Guid jobproviderId);
    }
}
