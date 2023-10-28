using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
	public class Companyrepository : ICompanyRepository
	{
		protected DbHireMeNowWebApiContext _context;

		public Companyrepository(DbHireMeNowWebApiContext context)
		{
			_context = context;
		}
	
		public async Task AddCompany(JobProviderCompany data)
		{
			try
			{
				_context.JobProviderCompanies.AddAsync(data);
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				
			}
		
		}
		public JobProviderCompany GetCompany(Guid companyId)
		{
			JobProviderCompany company = _context.JobProviderCompanies.Where(e => e.Id == companyId).Include(e => e.Location).Include(e => e.Industry).FirstOrDefault();
			return company;

		}
		public async Task<JobProviderCompany> updateCompanyAsync(JobProviderCompany company)
		{
			var companyToUpdate = await _context.JobProviderCompanies.Where(e => e.Id == company.Id).FirstOrDefaultAsync();
			if (companyToUpdate != null)
			{
				companyToUpdate.LegalName = company.LegalName ?? companyToUpdate.LegalName;
				companyToUpdate.Address = company.Address ?? companyToUpdate.Address;
				//companyToUpdate.Industry = company.Industry == null ? companyToUpdate.Industry : company.Industry;
				////companyToUpdate.Location = company.Location == null ? companyToUpdate.Location : company.Location;
				companyToUpdate.Email = company.Email ?? companyToUpdate.Email;
				companyToUpdate.Phone = company.Phone == null ? companyToUpdate.Phone : company.Phone;
				companyToUpdate.Website = company.Website == null ? company.Website : companyToUpdate.Website;
				companyToUpdate.Address = company.Address ?? companyToUpdate.Address;
				_context.JobProviderCompanies.Update(companyToUpdate);
				_context.SaveChanges();


			}
			else
			{
				throw new NotFoundException("Company Not Found");
			}
			return companyToUpdate;
		}

		//}
	}
}

