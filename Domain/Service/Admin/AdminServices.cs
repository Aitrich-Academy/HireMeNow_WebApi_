using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Admin.Interfaces;
using Domain.Service.Profile.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Admin
{
    public class AdminServices : IAdminServices
    {
        IAdminRepository _adminRepository;
        IMapper _mapper;
        public AdminServices(IAdminRepository adminRepository,IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
        }
        public async Task<List<Domain.Models.JobSeeker>> GetJobSeekers()
        {
            return await _adminRepository.GetJobSeekers();
        }

        public async Task<List<JobProviderCompany>> GetCompanies()
        {
            return await _adminRepository.GetCompanies();
        }

        public async Task<List<CompanyUser>> GetCompanyUsers()
        {
            return await _adminRepository.GetCompanyUsers();
        }

        public void DeleteById(Guid id)
        {
           _adminRepository.DeleteById(id);
        }

        public void DeleteCompaniesById(Guid id)
        {
            _adminRepository.DeleteCompaniesById(id);
        }

        public int GetCompanyCount()
        {
            return _adminRepository.GetCompanyCount();
        }

        public int GetJobProviderCount()
        {
            return _adminRepository.GetJobProviderCount();
        }

        public int GetJobCount()
        {
            return _adminRepository.GetJobCount();
        }
		public List<JobPost> GetJobs(JobListParams param)
        {
            return _adminRepository.GetJobs(param);
        }

        public async Task<bool> AddSkillAsync(SkillDto skill)
        {
            var Skill = _mapper.Map<Skill>(skill);
            var result =   await _adminRepository.AddAsync(Skill);

            return result;
        }

        public async Task<bool> RemoveSkillAsync(Guid skillId)
        {
            var result = await _adminRepository.RemoveAsync(skillId);

            return result;
        }
    }
}
