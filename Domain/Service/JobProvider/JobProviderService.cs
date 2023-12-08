﻿using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Authuser;
using Domain.Service.Authuser.Interfaces;
using Domain.Service.Job;
using Domain.Service.Job.Interfaces;
using Domain.Service.JobProvider.Interfaces;
using Domain.Service.JobSeeker;
using Domain.Service.JobSeeker.Interfaces;
using Domain.Service.SignUp.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
    public class JobProviderService:IJobProviderService
    {
        IJobProviderRepository _jobProviderRepository;
        IMapper _mapper;
        IEmailService _emailService;
        IAuthUserRepository _authUserRepository;
        public JobProviderService(IJobProviderRepository jobProviderRepository, IMapper mapper,IEmailService emailService, IAuthUserRepository authUserRepository)
        {
            _jobProviderRepository = jobProviderRepository;
            _mapper = mapper;
            _emailService = emailService;
             _authUserRepository = authUserRepository;
        }
        public async Task<List<JobPost>> GetJobs(Guid companyId)
        {
            return await _jobProviderRepository.GetJobs(companyId);
        }

        public async Task<List<JobPost>> GetAllJobsByProvider(Guid companyId, Guid jobproviderId)
        {
            return await _jobProviderRepository.GetAllJobsByProvider(companyId, jobproviderId);
        }

        public void PostJob(JobPost job)
        {
            _jobProviderRepository.Create(job);
        }

        public async Task<JobPost> GetJobById(Guid jobId)
        {
            return await _jobProviderRepository.GetJobById(jobId);
           
        }
        public async Task<JobPost> Update(JobPost job)
        {
            var updatedjob = await _jobProviderRepository.UpdateAsync(job);
            return updatedjob;
        }

        public void DeleteJob(Guid id)
        {
            _jobProviderRepository.DeleteJob(id);
        }

        public async void CreateSignupRequest(JobProviderSignupRequestDto data)
        {

            var signUpRequest = _mapper.Map<SignUpRequest>(data);
            var signUpId = _jobProviderRepository.AddSignupRequest(signUpRequest);
            MailRequest mailRequest = new MailRequest();
            mailRequest.Subject = "HireMeNow SignUp Verification";
            mailRequest.Body = "http://localhost:4200/set-password?signupid=" + signUpId.ToString();
            mailRequest.ToEmail = signUpRequest.Email;
            await _emailService.SendEmailAsync(mailRequest);
        }

        public async Task<bool> VerifyEmailAsync(Guid jobProviderSignupRequestId)
        {

            SignUpRequest signUpRequest = await _jobProviderRepository.GetSignupRequestByIdAsync(jobProviderSignupRequestId);
            if (signUpRequest != null)
            {
                signUpRequest.Status = Enums.Status.VERIFIED;
                _jobProviderRepository.UpdateSignupRequest(signUpRequest);
                return true;
            }
            return false;
        }

        public async Task CreateJobProvider(Guid jobProviderSignupRequestId, string password)
        {
            try
            {
                SignUpRequest signUpRequest = await _jobProviderRepository.GetSignupRequestByIdAsync(jobProviderSignupRequestId);
                //AuthUser authUser = mapper.Map<AuthUser>(signUpRequest);
                AuthUser authUser = new();
                if (signUpRequest.Status == Enums.Status.VERIFIED)
                {
                    //need to change this code by using Automapper 



                    authUser.UserName = signUpRequest.UserName;
                    authUser.Role = Enums.Role.JOB_PROVIDER;
                    authUser.FirstName = signUpRequest.FirstName;
                    authUser.LastName = signUpRequest.LastName;
                    authUser.Email = signUpRequest.Email;
                    authUser.Password = password;
                    authUser.Phone = signUpRequest.Phone;
                    authUser = await _authUserRepository.AddAuthUser(authUser);
                    signUpRequest.Status = Enums.Status.CREATED;
                    _jobProviderRepository.UpdateSignupRequest(signUpRequest);
                }

                Models.CompanyUser jobProvider = _mapper.Map<Models.CompanyUser>(authUser);

                //await jobSeekerRepository.AddJobSeekerAsync(jobseeker);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
