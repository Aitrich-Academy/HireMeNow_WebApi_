﻿using AutoMapper;
using Domain.Models;
using Domain.Service.Admin.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Admin
{
    public class AdminRepository:IAdminRepository
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
            int count =  _context.JobProviderCompanies.Count();
            return count;
        }

        public int GetJobProviderCount()
        {
            int count = _context.CompanyUsers.Count();
            return count;
        }
    }

}