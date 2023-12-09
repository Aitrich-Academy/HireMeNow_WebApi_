using Domain.Helpers;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Admin.Interfaces
{
    public interface IAdminRepository
    {
        public Task<List<Domain.Models.JobSeeker>> GetJobSeekers();
        public Task<List<JobProviderCompany>> GetCompanies();

        public Task<List<CompanyUser>> GetCompanyUsers();

        public void DeleteById(Guid id);

        public void DeleteCompaniesById(Guid id);
        /*        public Task<int> GetCompanyCount();*/
        public int GetCompanyCount();

        public int GetJobProviderCount();
        public Task<List<JobPost>> GetJobs(string JobLitle);

        public int GetJobCount();

       Task<bool> AddAsync(Skill skill);


        Task<List<JobProviderCompany>> SearchCompanies(string name);

    }
    
}
