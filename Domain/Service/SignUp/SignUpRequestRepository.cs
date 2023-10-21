using Domain.Enums;
using Domain.Models;
using Domain.Service.SignUp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.SignUp
{
    public class SignUpRequestRepository: ISignUpRequestRepository
    {
        protected readonly DbHireMeNowWebApiContext _context;
        public SignUpRequestRepository(DbHireMeNowWebApiContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddJobSeekerAsync(Models.JobSeeker jobseeker)
        {
           await _context.JobSeekers.AddAsync(jobseeker);
            _context.SaveChanges();

        }

        public Guid AddSignupRequest(SignUpRequest signUpRequest)
        {
            signUpRequest.Status=Status.PENDING;
           _context.SignUpRequests.AddAsync(signUpRequest);
            _context.SaveChanges();
            return signUpRequest.Id;
        }

        public async Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobSeekerSignupRequestId)
        {
           return await _context.SignUpRequests.FindAsync(jobSeekerSignupRequestId);
        }

        public  void UpdateSignupRequest(SignUpRequest signUpRequest)
        {
            _context.SignUpRequests.Update(signUpRequest);
             _context.SaveChanges();
        }
    }
}
