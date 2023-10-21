using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Authuser;
using Domain.Service.Authuser.Interfaces;

using Domain.Service.SignUp.DTOs;
using Domain.Service.SignUp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.SignUp
{
    public class SignUpRequestService : ISignUpRequestService
    {
        ISignUpRequestRepository jobSeekerRepository;
        IAuthUserRepository authUserRepository;
        IMapper mapper;
        IEmailService emailService;
        public SignUpRequestService(ISignUpRequestRepository _jobSeekerRepository,IMapper _mapper ,IEmailService _emailService, IAuthUserRepository _authUserRepository) {
            jobSeekerRepository=_jobSeekerRepository;
            mapper=_mapper;
            emailService=_emailService;
            authUserRepository=_authUserRepository;
        }

        public async Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password)
        {
            try
            {
                SignUpRequest signUpRequest = await jobSeekerRepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
                //AuthUser authUser = mapper.Map<AuthUser>(signUpRequest);

                //need to change this code by using Automapper 
                AuthUser authUser = new();
           
                authUser.UserName=signUpRequest.UserName;
                authUser.Role=Enums.Role.JOB_SEEKER;
                authUser.FirstName=signUpRequest.FirstName;
                authUser.LastName=signUpRequest.LastName;
                authUser.Email=signUpRequest.Email;
                authUser.Password= password;
                authUser.Phone=signUpRequest.Phone;
                authUser =await authUserRepository.AddAuthUser(authUser);

                Models.JobSeeker jobseeker = mapper.Map<Models.JobSeeker>(authUser);

                //await jobSeekerRepository.AddJobSeekerAsync(jobseeker);
            }catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async void CreateSignupRequest(JobSeekerSignupRequestDto data)
        {
            var signUpRequest= mapper.Map<SignUpRequest>(data);
          var signUpId=  jobSeekerRepository.AddSignupRequest(signUpRequest);
            MailRequest mailRequest= new MailRequest();
            mailRequest.Subject="HireMeNow SignUp Verification";
            mailRequest.Body=signUpId.ToString();
            mailRequest.ToEmail=signUpRequest.Email;
           await emailService.SendEmailAsync(mailRequest);
        }

        public async Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId)
        {
            SignUpRequest signUpRequest= await jobSeekerRepository.GetSignupRequestByIdAsync(jobSeekerSignupRequestId);
            if(signUpRequest != null && signUpRequest.Status==Enums.Status.PENDING)
            {
                signUpRequest.Status=Enums.Status.VERIFIED;
                 jobSeekerRepository.UpdateSignupRequest(signUpRequest);
                return true;
            }
            return false;
        }
    }
}
