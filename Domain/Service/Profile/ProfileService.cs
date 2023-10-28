using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Service.Profile.Interface;

namespace Domain.Service.Profile
{
    public class ProfileService : IJobSeekerProfileService
    {
        public readonly IJobSeekerProfileRepository _profileRepository;
        public ProfileService(IJobSeekerProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }


        public async Task AddSkillsToProfile(Guid jobseekerId, Guid profileId, List<Guid> skills)
        {
         var profile = await _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);

        if (profile != null)
        {
                List<JobSeekerProfileSkill> skillslist = new List<JobSeekerProfileSkill>();
                skills.ForEach(x =>
                {
                    JobSeekerProfileSkill jobSeekerProfileSkill = new JobSeekerProfileSkill();

                    jobSeekerProfileSkill.SkillId = x;
                    jobSeekerProfileSkill.JobSeekerProfileId = profile.Id;
                    skillslist.Add(jobSeekerProfileSkill);
                });
                profile.JobSeekerProfileSkills= skillslist;
            // Add the skills to the profile
            await _profileRepository.AddSkillsToProfile(profile);
        }
        else
        {
            throw new Exception("Profile not found");
        }
        }

        public async Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId)
        {
            return await _profileRepository.GetProfileAsync(jobSeekerId);
        }
    }
}
