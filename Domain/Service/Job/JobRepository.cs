using Domain.Models;
using Domain.Service.Job.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Service.Job
{
	public class JobRepository:IJobRepository
	{
		private readonly DbHireMeNowWebApiContext _context;

		public JobRepository(DbHireMeNowWebApiContext context)
		{
			_context = context;
		}

		public List<SavedJob> GellAllsavedJobs()
		{
			return _context.SavedJobs.ToList();
		}
	}
}
