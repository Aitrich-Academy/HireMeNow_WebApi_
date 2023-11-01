﻿using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.SignUp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.Interfaces
{
	public interface ICompanyService
	{
		Task  AddCompany(CompanyRegistrationDtos data);
		GetCompanyDetailsDto GetCompany(Guid companyId);
		Task<JobProviderCompany> UpdateAsync(CompanyUpdateDtos company);
		Task<PagedList<CompanyUser>> memberListing(Guid companyId,CompanyMemberListParam param);
		bool memberDeleteById(Guid id);
	}
}
