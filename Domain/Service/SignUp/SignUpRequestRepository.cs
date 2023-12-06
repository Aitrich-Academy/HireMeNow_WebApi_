using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Service.SignUp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public async Task addResume(Guid resumeId, string title, byte[] fileData)
        {
            var newResume = new Resume
            {
                Id = resumeId,
                Title = title,
                File = fileData
            };

            _context.Resumes.Add(newResume);
            await _context.SaveChangesAsync();
        }

        public async Task addResumeToProfile(Guid profileId, Guid resumeId, Guid jobSeekerId, string profileName, string profileSummary)
        {
            var newjobSeekerProfile = new JobSeekerProfile
            {
                Id = profileId,
                ResumeId = resumeId,
                JobSeekerId = jobSeekerId,
                ProfileName = profileName,
                ProfileSummary = profileSummary
            };

            _context.JobSeekerProfiles.Update(newjobSeekerProfile);
            await _context.SaveChangesAsync();
        }

        public async Task<Guid> getResumeId(Guid profileId)
        {
            var jobSeekerProfile = _context.JobSeekerProfiles.FirstOrDefault(s => s.Id == profileId);
            Guid resumeId = jobSeekerProfile.ResumeId.Value;
            return resumeId;
        }


        public async Task<byte[]> getResumeFile(Guid resumeId)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(r => r.Id == resumeId);
            if (resume == null)
            {
                return null; // or handle the case where the resume doesn't exist
            }
            return resume.File; // Assuming there's a property named ResumeData that contains the binary data.
        }

        public async Task UpdateResume(Guid resumeId, byte[] fileData)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(r => r.Id == resumeId);
            resume.File = fileData;
            await _context.SaveChangesAsync();
        }

		public async Task<List<Resume>> getResume(Guid resumeId)
        {
			return await _context.Resumes.Where(e => e.Id == resumeId).ToListAsync();
		}
		public async Task DeleteResume(Guid resumeId)
        {
            var resume = await _context.Resumes.FindAsync(resumeId);

            if (resume != null)
            {
                _context.Resumes.Remove(resume);
                await _context.SaveChangesAsync();
            }
        }

    }
}

