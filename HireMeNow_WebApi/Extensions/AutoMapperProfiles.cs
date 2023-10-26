using AutoMapper;
using Domain.Models;
using Domain.Service.Login.DTOs;
using Domain.Service.Job.DTOs;
using Domain.Service.JobProvider.DTOs;
using Domain.Service.SignUp.DTOs;
using HireMeNow_WebApi.API.JobSeeker.RequestObjects;

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
        }
    }
}
