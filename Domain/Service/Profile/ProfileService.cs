using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.JobSeeker;
using Domain.Service.Profile.DTOs;
using Domain.Service.Profile.Interface;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Domain.Service.Profile
{
    public class ProfileService : IJobSeekerProfileService
    {
        public readonly IJobSeekerProfileRepository _profileRepository;
        IMapper mapper;
        public ProfileService(IJobSeekerProfileRepository profileRepository, IMapper _mapper)
        {
            mapper = _mapper;
            _profileRepository = profileRepository;
        }

        //public async Task AddQualificationToProfile(Guid jobseekerId, Guid profileId, List<Guid> qualification)
        //{
        //   var profile = await _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
        //    if (profile != null)
        //    {

        //    }else
        //    {
        //        throw new Exception("Profile not found");
        //    }
        //}

        public void AddQualificationToProfile(Guid jobseekerId, Guid profileId, Qualification qualification)
        {
            var profile = _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            if (profile != null)
            {
                var Qualification = mapper.Map<Qualification>(qualification);
                _profileRepository.AddQualificationsToProfile(profileId, Qualification);

            }
            else
            {
                throw new Exception("Profile not found");
            }

        //public async Task AddQualificationToProfile(Guid jobseekerId, Guid profileId, List<Guid> qualification)
        //{
        //   var profile = await _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
        //    if (profile != null)
        //    {

        //    }else
        //    {
        //        throw new Exception("Profile not found");
        //    }
        //}

        public void AddQualificationToProfile(Guid jobseekerId, Guid profileId, Qualification qualification)
        {
            var profile = _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            if (profile != null)
            {
                var Qualification = mapper.Map<Qualification>(qualification);
                _profileRepository.AddQualificationsToProfile(profileId, Qualification);

            }
            else
            {
                throw new Exception("Profile not found");
            }

        }

        public Task AddQualificationToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerQualificationDTo jobseekerQualificationDTo)
        {
            var profile = _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            if (profile != null)
            {
                var Qualification = mapper.Map<Qualification>(jobseekerQualificationDTo);
                return _profileRepository.AddQualificationsToProfile(profileId, Qualification);

            }
            else
            {
                throw new Exception("Profile not found");
            }
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
                profile.JobSeekerProfileSkills = skillslist;
                // Add the skills to the profile
                await _profileRepository.AddSkillsToProfile(profile);
            }
            else
            {
                throw new Exception("Profile not found");
            }
        }

        public async Task AddWorkExpericeToProfileAsync(Guid jobseekerId, Guid profileId, JobseekerWorkExperienceDTo data)
        {
            //var profile = _profileRepository.GetJobSeekerProfileByIds(jobseekerId, profileId);
            //if (profile != null)
            //{
                var Experience = mapper.Map<WorkExperience>(data);
                await _profileRepository.AddWorkExperienceToProfile(profileId,Experience);

            //}
            //else
            //{
            //    throw new Exception("Profile not found");
            //}

                //var signUpRequest = mapper.Map<SignUpRequest>(data);
                //var signUpId = jobSeekerRepository.AddSignupRequest(signUpRequest);
                //MailRequest mailRequest = new MailRequest();
                //mailRequest.Subject = "HireMeNow SignUp Verification";
                //mailRequest.Body = signUpId.ToString();
                //mailRequest.ToEmail = signUpRequest.Email;
                //await emailService.SendEmailAsync(mailRequest);

            


        }

        public List<ExperienceDto> GetExperience(Guid jobseekerId, Guid profileId)
        {

            var workExperiences = _profileRepository.GetExperience(jobseekerId, profileId);
            var experienceDtos = mapper.Map<List<ExperienceDto>>(workExperiences);

            return experienceDtos;

        }

        public Task<JobSeekerProfile> GetProfileAsync(Guid jobSeekerId)
        {
            return _profileRepository.GetProfileAsync(jobSeekerId);
        }

        public List<JobseekerQualificationDTo> GetQualification(Guid profileId)
        {

            var Qualifications = _profileRepository.GetQualification(profileId);
            var QualificationDtos = mapper.Map<List<JobseekerQualificationDTo>>(Qualifications);

            return QualificationDtos;
            
        }

        public List<SkillDto> GetSkillsForJobSeekerProfile(Guid jobseekerId, Guid profileId)
        {
            return _profileRepository.GetSkillsForProfile(jobseekerId, profileId);
        }
    }
}