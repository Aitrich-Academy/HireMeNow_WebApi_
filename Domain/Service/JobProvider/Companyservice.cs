using AutoMapper;
using Domain.Models;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
	public class Companyservice:ICompanyService
	{
		IMapper mapper;
		ICompanyRepository companyRepository;

		public Companyservice(IMapper _mapper, ICompanyRepository _companyRepository)
		{
		mapper = _mapper;
		companyRepository = _companyRepository;
		}

		public async Task AddCompany(CompanyRegistrationDtos data)
		{
			var jobproviderCompany=mapper.Map<JobProviderCompany>(data);
			 companyRepository.AddCompany(jobproviderCompany);

			
		}
		public CompanyRegistrationDtos GetCompany(Guid companyId)
		{
			var company=companyRepository.GetCompany(companyId);	
			var compayRegistrationDtos=mapper.Map<CompanyRegistrationDtos>(company);
			return compayRegistrationDtos;
		}
		public async Task<JobProviderCompany> UpdateAsync(CompanyUpdateDtos company)
	{
			JobProviderCompany jobProviderCompany=mapper.Map<JobProviderCompany>(company);
			var jobProviderUpdatedCompany= await companyRepository.updateCompanyAsync(jobProviderCompany);
			//var ComapnyRegistrationDto = mapper.Map<CompanyRegistrationDtos>(jobProviderUpdatedCompany);
			return jobProviderUpdatedCompany;
		}
	}
}
