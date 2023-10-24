using Domain.Models;
using Domain.Service.Job.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job
{

	public class JobServices:IJobServices
	{
		private readonly IJobRepository _jobRepository;

		public JobServices(IJobRepository jobRepository)
		{
			_jobRepository = jobRepository;
		}

		public List<SavedJob> GellAllsavedJobs()
		{
			return _jobRepository.GellAllsavedJobs();
		}
	}
}
