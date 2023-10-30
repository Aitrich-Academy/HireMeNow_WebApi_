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
		public async Task<PagedList<SavedJob>> GetAllSavedJobsOfSeeker(Guid jobseekerId, JobListParams param)
		{
			try
			{
				// Making queryable
				var query = _context.SavedJobs.Where(e => e.SavedBy == jobseekerId)
				   .OrderByDescending(c => c.DateSaved).Include(e => e.JobPost)
				   //.ProjectTo<Job>(_mapper.ConfigurationProvider)
				   .AsQueryable();


				return await PagedList<SavedJob>.CreateAsync(query,
					param.PageNumber, param.PageSize);
			}
			catch(Exception ex)

			{
				throw ex;


			}
			
		
			//return _context.SavedJobs.Where(e => e.SavedBy == seekerId).Include(e => e.JobPost).Include(e => e.JobSeeker).ToListAsync();
		}
		
		public SavedJob GetsavedJobById(Guid jobseekerId, Guid SavedJobId)
		{
			var savedJob = _context.SavedJobs.Where(e => e.SavedBy == jobseekerId && e.Job == SavedJobId).Include(e=>e.JobPost).FirstOrDefault();
			return savedJob;
		}
		public SavedJob RemoveSavedJob(Guid seekerId,Guid jobid)
		{

			SavedJob savedjob= _context.SavedJobs.Where(e => e.SavedBy == seekerId && e.Id==jobid).FirstOrDefault();
			_context.Remove(savedjob);
			_context.SaveChanges();
			return savedjob;
			//return _context.SavedJobs.Where(e => e.SavedBy == seekerId).Include(e => e.JobPost).Include(e => e.JobSeeker).ToListAsync();
		}
		public async Task<PagedList<JobApplication>> GetAllAppliedJobs(Guid jobseekerId,JobListParams param)
		{
			var query = _context.JobApplications.Where(e => e.Applicant == jobseekerId).Include(e => e.JobPost).AsQueryable();



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
