using Domain.Models;
using Domain.Service.Profile;
using Domain.Service.Profile.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.JobSeeker
{
	
	[ApiController]
	public class JobSeekerProfileController : ControllerBase

	{
        private readonly IJobSeekerProfileService _profileService;
        public JobSeekerProfileController(IJobSeekerProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpGet("{jobseekerId}/profile")]
        public async Task<IActionResult> GetJobSeekerProfile(Guid jobseekerId)
        {
            try
            {
                var profile = await _profileService.GetProfileAsync(jobseekerId);
                if (profile == null)
                {
                    return NotFound();
                }

                return Ok(profile);
            }
            catch (Exception ex)
            {
                // Handle exceptions and log errors
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("{jobseekerId}/profile/{profileId}/skills")]
        public async Task<IActionResult> AddSkillsToProfile(Guid jobseekerId, Guid profileId, [FromBody] List<Guid> skills)
        {
            try
            {
                await _profileService.AddSkillsToProfile(jobseekerId, profileId, skills);
                return Ok("Skills added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to add skills: " + ex.Message);
            }
        }

    



    }
}
