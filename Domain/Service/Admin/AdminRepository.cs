using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Admin.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Domain.Service.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly List<Domain.Models.JobSeeker> _jobSeeker;
        DbHireMeNowWebApiContext _context;
        IMapper _mapper;

        public AdminRepository(DbHireMeNowWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Domain.Models.JobSeeker>> GetJobSeekers()
        {
            return await _context.JobSeekers.ToListAsync();
        }

        public async Task<List<JobProviderCompany>> GetCompanies()
        {
            return await _context.JobProviderCompanies.ToListAsync();
        }

        public async Task<List<CompanyUser>> GetCompanyUsers()
        {
            return await _context.CompanyUsers.ToListAsync();
        }

        public void DeleteById(Guid id)
        {
            var item = _context.CompanyUsers.Where(e => e.Id == id).FirstOrDefault();
            if (item != null)
            {
                _context.CompanyUsers.Remove(item);
                _context.SaveChanges();
            }
        }

        public void DeleteCompaniesById(Guid id)
        {
            var item = _context.JobProviderCompanies.Where(e => e.Id == id).FirstOrDefault();
            if (item != null)
            {
                _context.JobProviderCompanies.Remove(item);
                _context.SaveChanges();
            }
        }

        public int GetCompanyCount()
        {
            int count = _context.JobProviderCompanies.Count();
            return count;
        }

        public int GetJobProviderCount()
        {
            int count = _context.CompanyUsers.Count();
            return count;
        }

        public int GetJobCount()
        {
            int count = _context.JobPosts.Count();
            return count;
        }
        public async Task<List<JobPost>> GetJobs(string JobLitle)
        {


            return _context.JobPosts.Where(e => e.JobTitle.Contains(JobLitle)).ToList();

        }
        public async Task<List<JobPost>> GetJobs()
        {

            return _context.JobPosts.ToList();

        }


        public async Task<List<JobProviderCompany>> SearchCompanies(string name)

        {
            var filteredCompanies = await _context.JobProviderCompanies
           .Where(company => company.LegalName.Contains(name))
           .ToListAsync();

            return filteredCompanies;
        }

        public async Task<bool> AddAsync(Skill skill)
        {
            if (skill == null)
                throw new ArgumentNullException(nameof(skill));
            if (_context.Skills.Any(s => s.Name == skill.Name))
            {
                return false; // Skill with the same name already exists
            }
            skill.Id = Guid.NewGuid();
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return true; // Skill added successfully
        }

        public async Task<bool> RemoveAsync(Guid skillId)
        {
            var skillToRemove = await _context.Skills.FindAsync(skillId);

            if (skillToRemove == null)
            {
                return false; // Skill not found
            }

            _context.Skills.Remove(skillToRemove);
            await _context.SaveChangesAsync();

            return true; // Skill removed successfully
        }

    }
}
