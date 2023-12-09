﻿using AutoMapper;
using Domain.Helpers;
using Domain.Models;
using Domain.Service.Admin.Interfaces;
using Domain.Service.Job.DTOs;
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

        public AdminServices(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
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
		public async Task<List<JobPost>> GetJobs(string JobLitle)
        {
           var jobs= await _adminRepository.GetJobs(JobLitle);
		
			return jobs;


        }


        public Task<List<JobProviderCompany>> SearchCompanies(string name)
        {
            return _adminRepository.SearchCompanies(name);
        }
    }
}
