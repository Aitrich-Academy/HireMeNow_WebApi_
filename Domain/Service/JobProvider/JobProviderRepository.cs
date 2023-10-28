using AutoMapper;
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
            return await _context.JobPosts.Where(e => e.Company == companyId).ToListAsync();
        }

        public async Task<List<JobPost>> GetAllJobsByProvider(Guid companyId, Guid jobproviderId)
        {
            return await _context.JobPosts.Where(e => e.Company == companyId && e.PostedBy == jobproviderId).ToListAsync();
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
            
                jobToUpdate.Id = Updatedjob.Id ;
                jobToUpdate.JobTitle = Updatedjob.JobTitle;
                jobToUpdate.JobSummary = Updatedjob.JobSummary;
                jobToUpdate.JobLocation = Updatedjob.JobLocation;
                jobToUpdate.Company = Updatedjob.Company;
                jobToUpdate.Category = Updatedjob.Category;
                jobToUpdate.Industry = Updatedjob.Industry;
                _context.JobPosts.Update(jobToUpdate);
                await _context.SaveChangesAsync();
           
            return jobToUpdate;
        }

        public Task<JobPost> GetJobById(Guid jobId)
        {
            throw new NotImplementedException();
        }
    }
}
