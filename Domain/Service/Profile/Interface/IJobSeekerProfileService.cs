using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Service.Profile.DTOs;

namespace Domain.Service.Profile.Interface
{
    public interface IJobSeekerProfileService
    {
       
        
        Task AddSkillsToProfile(Guid jobseekerId, Guid profileId, List<Guid> skills);

        Task AddWorkExpericeToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerWorkExperienceDTo jobseekerWorkExperienceDTo);
        Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId);
        List<SkillDto> GetSkillsForJobSeekerProfile(Guid jobseekerId, Guid profileId);
    }
}
