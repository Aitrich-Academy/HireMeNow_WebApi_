using AutoMapper;
using Domain.Models;
using Domain.Service.Job.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.Job
{
    public class JobRepository : IJobRepository
    {
        private List<JobPost> jobs = new();

        private readonly List<JobPost> _jobs;
        DbHireMeNowWebApiContext _context;
        IMapper _mapper;

        public JobRepository(DbHireMeNowWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<JobPost>> GetJobs()
        {
            return await _context.JobPosts.ToListAsync();
        }

        public async Task<List<JobPost>> GetJobsByCompany(Guid companyId)
        {
            /*   return await _context.JobPosts.Include(j => j.Company== companyId).ToListAsync();*/
            return await _context.JobPosts.Where(e => e.Company == companyId).ToListAsync();
        }


        public async Task<List<JobPost>> GetJobsById(Guid companyId, Guid jobId)
        {
            return await _context.JobPosts.Where(e => e.Company == companyId && e.Id == jobId).ToListAsync();
        }
    }
}

