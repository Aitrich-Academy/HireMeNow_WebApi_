using AutoMapper;
using Domain.Enums;
using Domain.Models;
using Domain.Service.JobProvider.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
    public class JobProviderRepository:IJobProviderRepository
    {
        private List<JobPost> jobs = new();

        private readonly List<JobPost> _jobs;
        DbHireMeNowWebApiContext _context;
        IMapper _mapper;

        public JobProviderRepository(DbHireMeNowWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<JobPost>> GetJobs(Guid companyId)
        {
            return await _context.JobPosts.Where(e => e.CompanyId == companyId).ToListAsync();
        }

        public async Task<List<JobPost>> GetAllJobsByProvider(Guid companyId, Guid jobproviderId)
        {
            return await _context.JobPosts.Where(e => e.CompanyId == companyId && e.PostedBy == jobproviderId).ToListAsync();
        }

        public async void Create(JobPost job)
        {
            await _context.JobPosts.AddAsync(job);
            _context.SaveChanges();
        }

   /*     public async Task<List<JobPost>> GetJobById(Guid jobId)
        {
            return await _context.JobPosts.Where(j => j.Id == jobId).ToListAsync();
        }*/

        public async Task<JobPost> UpdateAsync(JobPost Updatedjob)
        {
            var jobToUpdate = _context.JobPosts.Find(Updatedjob.Id);
            
                jobToUpdate.Id = Updatedjob.Id;
                jobToUpdate.JobTitle = Updatedjob.JobTitle;
                jobToUpdate.JobSummary = Updatedjob.JobSummary;
                jobToUpdate.LocationId = Updatedjob.LocationId;
                jobToUpdate.Company = Updatedjob.Company;
                jobToUpdate.JobCategory = Updatedjob.JobCategory;
                jobToUpdate.Industry = Updatedjob.Industry;
                _context.JobPosts.Update(jobToUpdate);
                await _context.SaveChangesAsync();
           
            return jobToUpdate;
        }
        public void DeleteJob(Guid id)
        {
            var item = _context.JobPosts.Where(e => e.Id == id).FirstOrDefault();
            if (item != null)
            {
                _context.JobPosts.Remove(item);
                _context.SaveChanges();
            }
        }
        public Task<JobPost> GetJobById(Guid jobId)
        {
            throw new NotImplementedException();
        }

        public Guid AddSignupRequest(SignUpRequest signUpRequest)
        {
            signUpRequest.Status = Status.PENDING;
            _context.SignUpRequests.AddAsync(signUpRequest);
            _context.SaveChanges();
            return signUpRequest.Id;
        }

        public async Task<SignUpRequest> GetSignupRequestByIdAsync(Guid jobProviderSignupRequestId)
        {
            return await _context.SignUpRequests.FindAsync(jobProviderSignupRequestId);
        }

        public void UpdateSignupRequest(SignUpRequest signUpRequest)
        {
            _context.SignUpRequests.Update(signUpRequest);
            _context.SaveChanges();
        }

    }
}
