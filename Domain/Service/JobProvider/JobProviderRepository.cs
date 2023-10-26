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
    }
}
