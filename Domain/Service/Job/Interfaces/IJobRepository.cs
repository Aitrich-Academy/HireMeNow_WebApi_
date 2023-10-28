

﻿using Domain.Helpers;
using Domain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.Interfaces
{
	public interface IJobRepository
	{

        Task<List<JobPost>> GetJobs();
        Task<List<JobPost>> GetJobsByCompany(Guid companyId);

        Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId);

		Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(JobListParams param);
		Task<PagedList<JobApplication>> GetAllAppliedJobs(JobListParams param);

		SavedJob RemoveSavedJob(Guid seekerId, Guid jobid);
	}

}
