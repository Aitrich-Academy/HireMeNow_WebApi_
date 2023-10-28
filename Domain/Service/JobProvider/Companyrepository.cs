using Domain.Models;
using Domain.Service.JobProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
	public class Companyrepository:ICompanyRepository
	{
		protected DbHireMeNowWebApiContext _context;

		public Companyrepository(DbHireMeNowWebApiContext context)
		{
			_context = context;
		}

		//public async Task AddJobSeekerAsync( jobseeker)
		//{
		//	await _context.JobProviderCompanies.AddAsync(jobseker);
		//	_context.SaveChanges();

		//}
	}
}
