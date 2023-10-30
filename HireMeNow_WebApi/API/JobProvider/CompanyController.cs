using AutoMapper;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.JobProvider.Interfaces;
using Domain.Service.JobSeeker;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.API.JobProvider.RequestObjects;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HireMeNow_WebApi.API.JobProvider
{
	
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Roles = "ADMIN")]
	public class CompanyController : ControllerBase
	{
		public CompanyController(IMapper _mapper, ICompanyService _companyService)
		{
			mapper = _mapper;
			companyService = _companyService;
		}

		public IMapper mapper { get; set; }
		public ICompanyService companyService { get; set; }
		[AllowAnonymous]
		[HttpPost]
		[Route("job-provider/{jobproviderId}/company")]
		
		public async Task<ActionResult> AddCompany(Guid jobproviderId, AddCompanyRequestobject data)
		{
			var companyRegistrationDtos = mapper.Map<CompanyRegistrationDtos>(data);
			await companyService.AddCompany(companyRegistrationDtos);
			return Ok();
		}
		[AllowAnonymous]
		[HttpGet]
		[Route("job-provider/company/{companyId}")]
		public async Task<ActionResult> AddCompany(Guid companyId)
		{
			var company=companyService.GetCompany(companyId);
			if(company == null) {
				return BadRequest("Company Not found");

			}
			else
			{
				return Ok(company);
			}

		
		}
		[AllowAnonymous]
		[HttpPut]
		[Route("job-provider/company/{companyId}")]
		public async Task<ActionResult> UpdateCompany(Guid companyId,CompanyupdateRequest comapny)
		{
			if(companyId==null)
			{
				return BadRequest("Id is Required");
			}
			comapny.Id = companyId;
			var companyUpdateDtos = mapper.Map<CompanyUpdateDtos>(comapny);
			var updatedCompany = await companyService.UpdateAsync(companyUpdateDtos);
			//CompanyupdateRequest companyupdateRequest = mapper.Map<CompanyupdateRequest>(updatedCompany);
			if (updatedCompany == null)
			{
				return BadRequest("Company Not found");

			}
			else
			{
				return Ok(updatedCompany);
			}

		}


	}
}
