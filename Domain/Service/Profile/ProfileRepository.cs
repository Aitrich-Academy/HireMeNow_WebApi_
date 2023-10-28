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
            _context = context;
        }

     
        public async Task AddSkillsToProfile(JobSeekerProfile profile)
        {
            if (profile != null)
            {
                //foreach (var skillName in skills)
                //{
                //    var skill = new Skill {Name = skillName }; // Adjust property name according to your Skill model
                //    profile.JobSeekerProfileSkills.Add(new JobSeekerProfileSkill { Skill = skill });
                //}

                _context.JobSeekerProfiles.Update(profile);
                 _context.SaveChanges();
            }
        }

        public async Task<JobSeekerProfile?> GetJobSeekerProfileByIds(Guid jobseekerId, Guid profileId)
        {
            return await _context.JobSeekerProfiles
             .FirstOrDefaultAsync(profile => profile.JobSeekerId == jobseekerId && profile.Id == profileId);
        }

        public async Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId)
        {
            return await _context.JobSeekerProfiles
                        .Where(profile => profile.JobSeekerId == jobSeekerId)
                        .Include(profile => profile.Resume) // Include related entities if needed
                        .Include(profile => profile.JobSeekerProfileSkills) // Include related entities if needed

                        .Include(profile => profile.Qualifications) // Include related entities if needed
                        .Include(profile => profile.WorkExperiences) // Include related entities if needed
                        .FirstOrDefaultAsync();
        }
    }
}
