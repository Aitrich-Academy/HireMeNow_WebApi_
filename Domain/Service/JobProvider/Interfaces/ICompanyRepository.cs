﻿using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.Interfaces
{
	public interface ICompanyRepository
	{
		Task AddCompany(JobProviderCompany data);
		JobProviderCompany GetCompany(Guid companyId);
		Task<JobProviderCompany> updateCompanyAsync(JobProviderCompany company);
	}
}
