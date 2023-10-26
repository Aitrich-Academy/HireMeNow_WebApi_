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
	public class JobRepository:IJobRepository
	{
		private DbHireMeNowWebApiContext _context;

		public JobRepository(DbHireMeNowWebApiContext context)
		{
			_context = context;
		}
		public async Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(JobListParams param)
		{
			// Making queryable
			var query = _context.SavedJobs
			   .OrderByDescending(c => c.DateSaved)
			   //.ProjectTo<Job>(_mapper.ConfigurationProvider)
			   .AsQueryable();
			if(param.UserId!=null)
			{
				query = query.Where(c => c.SavedBy==param.UserId).Include(e=>e.JobPost);
			}

			return await PagedList<SavedJob>.CreateAsync(query,
				param.PageNumber, param.PageSize);
		
			//return _context.SavedJobs.Where(e => e.SavedBy == seekerId).Include(e => e.JobPost).Include(e => e.JobSeeker).ToListAsync();
		}
		public SavedJob RemoveSavedJob(Guid seekerId,Guid jobid)
		{

			SavedJob savedjob= _context.SavedJobs.Where(e => e.SavedBy == seekerId && e.Job==jobid).FirstOrDefault();
			_context.Remove(savedjob);
			_context.SaveChanges();
			return savedjob;
			//return _context.SavedJobs.Where(e => e.SavedBy == seekerId).Include(e => e.JobPost).Include(e => e.JobSeeker).ToListAsync();
		}
		public async Task<PagedList<JobApplication>> GetAllAppliedJobs(JobListParams param)
		{
			var query = _context.AppliedJobs.AsQueryable();
			if (param.UserId != null)
			{
				query = query.Where(c => c.Applicant == param.UserId).Include(e => e.JobPost);
			}

			return await PagedList<JobApplication>.CreateAsync(query,
				param.PageNumber, param.PageSize);
		}
	}
}
