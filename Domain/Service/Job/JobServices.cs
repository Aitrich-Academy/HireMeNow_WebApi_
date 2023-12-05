
using Domain.Models;
using Domain.Service.Job.Interfaces;
using Domain.Service.JobSeeker.Interfaces;

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
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;

namespace Domain.Service.Job
{
    public class JobServices : IJobServices
    {
        private IJobRepository _jobrepository;
        private IMapper _mapper;

        public JobServices(IJobRepository jobrepository, IMapper mapper)
        {
            _jobrepository = jobrepository;
            _mapper = mapper;
        }
        public async Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(Guid jobseekerId, JobListParams param)
        {
            var savedJobs = await _jobrepository.GetAllSavedJobsOfSeeker(jobseekerId, param);
            //var savedjobsDto = _mapper.Map<PagedList<SavedJob>>(savedJobs);
            return savedJobs;
        }

        public async Task<List<JobPostsDtos>> GetJobs(Guid userId)
        {
            var notApplied = await _jobrepository.GetJobs(userId);
            var dtoList = _mapper.Map<List<JobPost>, List<JobPostsDtos>>(notApplied);

            foreach (var job in dtoList)
            {
                job.Saved = _jobrepository.SavedJobs(job, userId);
            }

            return dtoList;
        }

        public async Task<List<JobPost>> GetJobsByCompany(Guid companyId)
        {
            return await _jobrepository.GetJobsByCompany(companyId);
        }

        public async Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId)
        {
            return await _jobrepository.GetJobsById(companyId,jobId);
        }
		public async Task<PagedList<AppliedJobsDtos>> GetAllAppliedJobs(Guid jobseekerId, JobListParams param)
		{
			var appliedjobs= await _jobrepository.GetAllAppliedJobs(jobseekerId, param);

			var appliedjobsDto = _mapper.Map<PagedList<AppliedJobsDtos>>(appliedjobs);
			return appliedjobsDto;
		}
		public  SavedJob RemoveSavedJob(Guid seekerId, Guid jobid)
		{

			return _jobrepository.RemoveSavedJob(seekerId, jobid);	
		}
		

		public bool ApplyJob(JobApplication applyJob)

		{
			
			return _jobrepository.applyjob(applyJob);
		}
		public async Task<SavedJob> saveJob(SavedJob savedJob)
		{
			return await _jobrepository.saveJob(savedJob);
		}
		public  bool CancelAppliedJob(Guid jobseekerId, Guid JobApplicationId)
		{
			return _jobrepository.CancelAppliedJob(jobseekerId, JobApplicationId);
		}
		public SavedJobsDtos GetsavedJobById(Guid jobseekerId, Guid SavedJobId)
		{
			var savedJob=_jobrepository.GetsavedJobById(jobseekerId, SavedJobId);

			var SavedJobsDto = _mapper.Map<SavedJobsDtos>(savedJob);
			return SavedJobsDto;	
		}


    }

}
