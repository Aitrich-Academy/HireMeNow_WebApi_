using Domain.Models;
using Domain.Service.Job.Interfaces;
using Domain.Service.JobSeeker.Interfaces;
using Domain.Service.SignUp.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job
{
	public class JobServices:IJobServices
	{
		private IJobRepository _jobrepository;

		public JobServices(IJobRepository jobrepository)
		{
			_jobrepository = jobrepository;
		}
		public async Task<List<SavedJob>> GetAllSavedJobsOfSeeker(Guid seekerId)
		{
			return await _jobrepository.GetAllSavedJobsOfSeeker(seekerId);
		}
	}
}
