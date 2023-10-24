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
		public Task<List<SavedJob>> GetAllSavedJobsOfSeeker(Guid seekerId)
		{
			return _context.SavedJobs.Where(e => e.SavedBy == seekerId).ToListAsync();
		}
	}
}
