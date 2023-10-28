using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Service.Profile.Interface
{
    public interface IJobSeekerProfileService
    {
        Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId);
    }
}
