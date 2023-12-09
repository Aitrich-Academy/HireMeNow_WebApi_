﻿using Domain.Helpers;
using Domain.Models;
using Domain.Service.Job.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Admin.Interfaces
{
    public interface IAdminServices
    {
        public Task<List<Domain.Models.JobSeeker>> GetJobSeekers();

        public Task<List<JobProviderCompany>> GetCompanies();

        public Task<List<CompanyUser>> GetCompanyUsers();
        
        public void DeleteById(Guid id);

        public void DeleteCompaniesById(Guid id);

        public int GetCompanyCount();
        public Task<List<JobPost>> GetJobs(string Title);
        public int GetJobProviderCount();
        public int GetJobCount();
 
        public  Task<List<JobProviderCompany>> SearchCompanies(string name);
    }
    
}
