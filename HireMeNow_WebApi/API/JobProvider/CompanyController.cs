using AutoMapper;
using Domain.Helpers;
using Domain.Service.Authuser.Interfaces;
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
	[Authorize(Roles = "JOB_PROVIDER")]
	public class CompanyController : ControllerBase
	{
		public CompanyController(IMapper _mapper, ICompanyService _companyService,IAuthUserService _authUserService)
		{
			mapper = _mapper;
			companyService = _companyService;
			authUserService = _authUserService;
		}

		public IMapper mapper { get; set; }
		public ICompanyService companyService { get; set; }
		public IAuthUserService	authUserService { get; set; }
		[AllowAnonymous]
		[HttpPost]
		[Route("job-provider/{jobproviderId}/company")]
		
		public async Task<ActionResult> AddCompany(Guid jobproviderId, AddCompanyRequestobject data)
		{
			var UserId = authUserService.GetUserId();
			var companyRegistrationDtos = mapper.Map<CompanyRegistrationDtos>(data);
			await companyService.AddCompany(companyRegistrationDtos);
			return Ok();
		}
		[AllowAnonymous]
		[HttpGet]
		[Route("job-provider/company/{companyId}")]
		public async Task<ActionResult> getCompany(Guid companyId)
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
		[AllowAnonymous]
		[HttpGet]
		[Route("job-provider/company/{companyId}/listcompanymember")]
		public async Task<ActionResult> ListCompanyMember(Guid companyId, [FromQuery] CompanyMemberListParam param)

		{

			if (companyId == null)
			{
				return BadRequest("Id is Required");
			}
			
			var CompanyMembers =  await companyService.memberListing(companyId,param);

			PagedList<CompanyMemberListDtos> companyMemberList = mapper.Map<PagedList<CompanyMemberListDtos>>(CompanyMembers);
			if (CompanyMembers == null)
			{
				return BadRequest("No Company Members");

			}
			else
			{
				return Ok(CompanyMembers);
			}

		}
		[AllowAnonymous]
		[HttpDelete]
		[Route("job-provider/company/{companyMemberId}/RemoveCompanyMember")]
		public IActionResult memberDelete(Guid companyMemberId)
		{
			var result=companyService.memberDeleteById(companyMemberId);
			if(result==true)
			{
				return Ok("Success fully remove the companyMember");

			}
			else
			{
				return BadRequest();
			}
		}





	}
}
