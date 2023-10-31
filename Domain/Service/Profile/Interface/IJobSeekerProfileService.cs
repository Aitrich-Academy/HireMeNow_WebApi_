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
        Task AddQualificationToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerQualificationDTo jobseekerQualificationDTo);

        Task AddSkillsToProfile(Guid jobseekerId, Guid profileId, List<Guid> skills);

        Task AddWorkExpericeToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerWorkExperienceDTo jobseekerWorkExperienceDTo);
        List<ExperienceDto> GetExperience(Guid jobseekerId, Guid profileId);
        Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId);
        List<JobseekerQualificationDTo> GetQualification(Guid profileId);
        List<SkillDto> GetSkillsForJobSeekerProfile(Guid jobseekerId, Guid profileId);
    }
}
