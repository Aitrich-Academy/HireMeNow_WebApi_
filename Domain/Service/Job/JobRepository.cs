
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

        public Task<PagedList<JobApplication>> GetAllAppliedJobs(JobListParams param)
        {
            throw new NotImplementedException();
        }

        public Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(JobListParams param)
        {
            throw new NotImplementedException();
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

			return await PagedList<JobApplication>.CreateAsync(query,
				param.PageNumber, param.PageSize);
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
			
	}
}
        public SavedJob RemoveSavedJob(Guid seekerId, Guid jobid)
        {
            throw new NotImplementedException();
        }
    }


		//public async Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(JobListParams param)
		//{
		//	// Making queryable
		//	var query = _context.SavedJobs
		//	   .OrderByDescending(c => c.DateSaved)
		//	   //.ProjectTo<Job>(_mapper.ConfigurationProvider)
		//	   .AsQueryable();
		//	if(param.UserId!=null)
		//	{
		//		query = query.Where(c => c.SavedBy==param.UserId).Include(e=>e.JobPost);
		//	}

		//	return await PagedList<SavedJob>.CreateAsync(query,
		//		param.PageNumber, param.PageSize);
		
		//	//return _context.SavedJobs.Where(e => e.SavedBy == seekerId).Include(e => e.JobPost).Include(e => e.JobSeeker).ToListAsync();
		//}
		//public SavedJob RemoveSavedJob(Guid seekerId,Guid jobid)
		//{

		//	SavedJob savedjob= _context.SavedJobs.Where(e => e.SavedBy == seekerId && e.Job==jobid).FirstOrDefault();
		//	_context.Remove(savedjob);
		//	_context.SaveChanges();
		//	return savedjob;
		//	//return _context.SavedJobs.Where(e => e.SavedBy == seekerId).Include(e => e.JobPost).Include(e => e.JobSeeker).ToListAsync();
		//}
		//public async Task<PagedList<JobApplication>> GetAllAppliedJobs(JobListParams param)
		//{
		//	var query = _context.JobApplications.AsQueryable();
		//	if (param.UserId != null)
		//	{
		//		query = query.Where(c => c.Applicant == param.UserId).Include(e => e.JobPost);
		//	}

		//	return await PagedList<JobApplication>.CreateAsync(query,
		//		param.PageNumber, param.PageSize);
		//}
	}



