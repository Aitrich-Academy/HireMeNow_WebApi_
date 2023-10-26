using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.Interfaces
{
	public interface IJobServices
	{
		Task<PagedList<SavedJobsDtos>> GetAllSavedJobsOfSeeker(JobListParams param);

		SavedJob RemoveSavedJob(Guid seekerId, Guid jobid);
		Task<PagedList<AppliedJobsDtos>> GetAllAppliedJobs(JobListParams param);

	}
}
