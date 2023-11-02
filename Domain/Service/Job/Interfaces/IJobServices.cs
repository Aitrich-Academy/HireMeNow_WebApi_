﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.Interfaces
{
    public interface IJobServices
	{
        public Task<List<JobPost>> GetJobs();

        public Task<List<JobPost>> GetJobsByCompany(Guid companyId);

        public Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId);

    }
}
