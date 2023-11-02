﻿using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.Interfaces;
using Microsoft.EntityFrameworkCore;


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
	
		public async Task AddCompany(JobProviderCompany data, Guid UserId)
		{
			try
			{
				_context.JobProviderCompanies.AddAsync(data);
				await _context.SaveChangesAsync();
				var CmpanyId = data.Id;
				AuthUser user = _context.AuthUsers.Where(e => e.Id == UserId).FirstOrDefault();
				CompanyUser companyUser = new CompanyUser();
				var cmp=_context.CompanyUsers.Where(e=>e.Id == UserId).FirstOrDefault();
				if(cmp==null)
				{
					companyUser.Id = UserId;
					companyUser.UserName = user.UserName;
					companyUser.Email = user.Email;
					companyUser.FirstName = user.FirstName;
					companyUser.LastName = user.LastName;
					companyUser.Phone = user.Phone;
					companyUser.Role = Enums.Role.COMPANY_USER;
					companyUser.Company = CmpanyId;
					_context.CompanyUsers.AddAsync(companyUser);
					await _context.SaveChangesAsync();
				}
				

				
			}
			catch (Exception ex)
			{
				
			}
		
		}
		public JobProviderCompany GetCompany(Guid companyId)
		{
			JobProviderCompany company = _context.JobProviderCompanies.Where(e => e.Id == companyId).FirstOrDefault();
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
				throw new FileNotFoundException("Company Not Found");
			}
			return companyToUpdate;
		}
		public async Task<PagedList<CompanyUser>> memberListing(Guid companyId,CompanyMemberListParam param)
		{
			var query =   _context.CompanyUsers.Where(e => e.Company == companyId)
		   .AsQueryable();


			return await PagedList<CompanyUser>.CreateAsync(query,
				param.PageNumber, param.PageSize);
		}
		public bool memberDeleteById(Guid id)
		{
			CompanyUser user = _context.CompanyUsers.Where(e => e.Id == id).FirstOrDefault();
			if (user != null)
			{
				_context.CompanyUsers.Remove(user);
				_context.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}
		}

	
	

		

	}
}

