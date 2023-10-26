using Domain.Models;
using Domain.Service.SignUp.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.SignUp.Interfaces
{
    public interface ISignUpRequestService
    {
        Task CreateJobseeker(Guid jobSeekerSignupRequestId, string password);

        //Task<Guid> AddJobseekerSignUpRequest(JobSeekerSignupRequest jobseekerCreateRequest);
        void CreateSignupRequest(JobSeekerSignupRequestDto data);
       
        Task<bool> VerifyEmailAsync(Guid jobSeekerSignupRequestId);
    }
}
