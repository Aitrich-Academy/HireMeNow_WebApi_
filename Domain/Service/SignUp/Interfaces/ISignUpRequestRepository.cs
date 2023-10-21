using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.SignUp.Interfaces
{
    public interface ISignUpRequestRepository
    {
        Task AddJobSeekerAsync(Models.JobSeeker jobseeker);
        Guid AddSignupRequest(SignUpRequest signUpRequest);
        Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId);
        void UpdateSignupRequest(SignUpRequest signUpRequest);
    }
}
