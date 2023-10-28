using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Service.Profile.Interface;
using Microsoft.EntityFrameworkCore;

namespace Domain.Service.Profile
{
    public class ProfileRepository : IJobSeekerProfileRepository
    {
        protected readonly DbHireMeNowWebApiContext _context;
        public ProfileRepository(DbHireMeNowWebApiContext context)
        {
            context = _context;
        }

        public async Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId)
        {
            return await _context.JobSeekerProfiles
                        .Where(profile => profile.JobSeekerId == jobSeekerId)
                        .Include(profile => profile.Resume) // Include related entities if needed
                        .Include(profile => profile.Qualifications) // Include related entities if needed
                        .Include(profile => profile.WorkExperiences) // Include related entities if needed
                        .FirstOrDefaultAsync();
        }
    }
}
