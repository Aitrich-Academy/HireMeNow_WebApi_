using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Service.Profile.DTOs;

namespace Domain.Service.Profile.Interface
{
    public interface IJobSeekerProfileRepository
    {
   
        Task AddSkillsToProfile(JobSeekerProfile profile);
        Task AddWorkExperienceToProfile(Guid profileId, WorkExperience experience);
        //void AddQualificationToProfile(Guid profileId, Qualification qualification);
        Task<JobSeekerProfile?>GetJobSeekerProfileByIds(Guid jobseekerId, Guid profileId);
        Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId);
        List<SkillDto> GetSkillsForProfile(Guid jobseekerId, Guid profileId);
        List<WorkExperience> GetExperience(Guid jobseekerId, Guid profileId);
        Task AddQualificationsToProfile(Guid profileId, Qualification qualification);
    }
}
