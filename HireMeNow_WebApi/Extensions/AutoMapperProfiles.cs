
using AutoMapper;
using Domain.Models;
using Domain.Service.Job.DTOs;
using Domain.Service.JobProvider.Dtos;
using Domain.Service.Login.DTOs;
using Domain.Service.Job.DTOs;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.API.Job.SavedJobObjects;
using HireMeNow_WebApi.API.JobProvider.RequestObjects;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;
using Domain.Helpers;

namespace HireMeNow_WebApi.Extensions
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
          
            CreateMap<JobSeekerSignupRequestDto, SignUpRequest>().ReverseMap();
			CreateMap<JobSeekerSignupRequest, JobSeekerSignupRequestDto>().ReverseMap();
			CreateMap<SignUpRequest, SystemUser>().ReverseMap();
            CreateMap<AuthUser, Domain.Models.JobSeeker>().ReverseMap();
            CreateMap<AuthUser, SystemUser>().ReverseMap();

            CreateMap<JobPost, JobPostsDtos>().ReverseMap();
            CreateMap<JobPost, JobProviderDto>().ReverseMap();
        

            CreateMap<AuthUser, JobSeekerLoginDto>();

            CreateMap<ApplyJobRequest, JobApplication>();
            CreateMap<JobApplication, AppliedJobsDtos>();
            CreateMap<CompanyRegistrationDtos, JobProviderCompany>().ReverseMap();
            CreateMap<AddCompanyRequestobject, JobProviderCompany>().ReverseMap();
			CreateMap<CompanyRegistrationDtos, AddCompanyRequestobject>().ReverseMap();
            CreateMap<CompanyUpdateDtos, CompanyupdateRequest>().ReverseMap();
            CreateMap<CompanyUpdateDtos,JobProviderCompany>().ReverseMap();
            CreateMap<SavedJob,SavedJobsDtos>().ReverseMap();
            CreateMap<JobProviderCompany, GetCompanyDetailsDto>();
           CreateMap<InterviewSheduleObject,InterviewsheduleDtos>();    
            CreateMap<InterviewsheduleDtos,Interview>();
			CreateMap<SheduledInterviewDto,Interview>();
			CreateMap<Interview, SheduledInterviewDto>();
            CreateMap<CompanyUser, CompanyMemberListDtos>().ReverseMap();
	

		}

		
	}
}
