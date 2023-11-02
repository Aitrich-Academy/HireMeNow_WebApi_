
﻿using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Domain.Service.Job
{
    public class JobRepository : IJobRepository
    {
       

       
        DbHireMeNowWebApiContext _context;
        IMapper _mapper;

        public JobRepository(DbHireMeNowWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
			public async Task<PagedList<JobApplication>> GetAllAppliedJobs(Guid jobseekerId, JobListParams param)
			{
			try
			{
				var query = _context.JobApplications.AsQueryable().Where(e => e.Applicant == jobseekerId).Include(e => e.JobPost);


				return await PagedList<JobApplication>.CreateAsync(query,
					param.PageNumber, param.PageSize);
			}
			catch(Exception ex)
			{
				throw ex;
			}
				
			}
		

        public async  Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(Guid jobseekerId,JobListParams param)
        {

			var query = _context.SavedJobs
			   .OrderByDescending(c => c.DateSaved).Where(e=>e.SavedBy==jobseekerId).Include(e=>e.JobPost).AsQueryable();
			return await PagedList<SavedJob>.CreateAsync(query,
				param.PageNumber, param.PageSize);
		}

        public async Task<List<JobPost>> GetJobs()
        {
            return await _context.JobPosts.ToListAsync();
        }

        public async Task<List<JobPost>> GetJobsByCompany(Guid companyId)
        {
            /*   return await _context.JobPosts.Include(j => j.Company== companyId).ToListAsync();*/
            return await _context.JobPosts.Where(e => e.Company == companyId).ToListAsync();
        }


        public async Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId)
        {
            return await _context.JobPosts.Where(e => e.Company == companyId && e.Id == jobId).ToListAsync();
        }

			
	
		public bool applyjob(JobApplication applyjob)
		{
			applyjob.status = Enums.Status.PENDING;
		_context.JobApplications.Add(applyjob);
			_context.SaveChanges();
			return true;

		}
		public bool CancelAppliedJob(Guid jobseekerId, Guid JobApplicationId)
		{
			try
			{
				var AppliedJob = _context.JobApplications.Where(e=> e.Id == JobApplicationId).FirstOrDefault();
				if (AppliedJob != null)
				{
					_context.JobApplications.Remove(AppliedJob);
					_context.SaveChanges();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch (Exception ex) {
				throw (ex);
			}
			}
			
	

        public SavedJob RemoveSavedJob(Guid seekerId, Guid jobid)
        {
			var savedjob = _context.SavedJobs.Where(e => e.SavedBy == seekerId && e.Id == jobid).FirstOrDefault();
			_context.SavedJobs.Remove(savedjob); 
			_context.SaveChanges();
			return savedjob;
        }

		public SavedJob GetsavedJobById(Guid jobseekerId, Guid SavedJobId)
		{
			throw new NotImplementedException();
		}
	}



	//public SavedJob RemoveSavedJob(Guid seekerId,Guid jobid)
	//{

	//	SavedJob savedjob= _context.SavedJobs.Where(e => e.SavedBy == seekerId && e.Job==jobid).FirstOrDefault();
	//	_context.Remove(savedjob);
	//	_context.SaveChanges();
	//	return savedjob;
	//	//return _context.SavedJobs.Where(e => e.SavedBy == seekerId).Include(e => e.JobPost).Include(e => e.JobSeeker).ToListAsync();
	//}

}



    public class JobRepository : IJobRepository
    {
        private List<JobPost> jobs = new();

        private readonly List<JobPost> _jobs;
        DbHireMeNowWebApiContext _context;
        IMapper _mapper;

        public JobRepository(DbHireMeNowWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<JobPost>> GetJobs()
        {
            return await _context.JobPosts.ToListAsync();
        }

        public async Task<List<JobPost>> GetJobsByCompany(Guid companyId)
        {
            /*   return await _context.JobPosts.Include(j => j.Company== companyId).ToListAsync();*/
            return await _context.JobPosts.Where(e => e.Company == companyId).ToListAsync();
        }


        public async Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId)
        {
            return await _context.JobPosts.Where(e => e.Company == companyId && e.Id == jobId).ToListAsync();
        }
    }
}

