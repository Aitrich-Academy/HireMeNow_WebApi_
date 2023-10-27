using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.DTOs;
using Domain.Service.Job.Interfaces;
using Domain.Service.JobSeeker.Interfaces;
using Domain.Service.Login.DTOs;
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
		private IMapper _mapper;

		public JobServices(IJobRepository jobrepository,IMapper mapper)
		{
			_jobrepository = jobrepository;
			_mapper = mapper;	
		}
		public async Task<PagedList<SavedJobsDtos>> GetAllSavedJobsOfSeeker(JobListParams param)
		{
			var savedJobs = await _jobrepository.GetAllSavedJobsOfSeeker(param);
			var savedjobsDto = _mapper.Map<PagedList<SavedJobsDtos>>(savedJobs);
			return savedjobsDto;



		}
		public async Task<PagedList<AppliedJobsDtos>> GetAllAppliedJobs(JobListParams param)
		{
			var appliedjobs=await _jobrepository.GetAllAppliedJobs(param);

			var appliedjobsDto = _mapper.Map<PagedList<AppliedJobsDtos>>(appliedjobs);
			return appliedjobsDto;



		}
		public  SavedJob RemoveSavedJob(Guid seekerId, Guid jobid)
		{
			return _jobrepository.RemoveSavedJob(seekerId, jobid);	
		}

	}
}
