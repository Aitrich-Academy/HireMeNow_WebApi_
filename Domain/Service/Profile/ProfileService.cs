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
            profileRepository = profileRepository;
        }
        public async Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId)
        {
            return await _profileRepository.GetProfileAsync(jobSeekerId);
        }
    }
}
