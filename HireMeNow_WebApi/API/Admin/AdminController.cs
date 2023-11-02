using AutoMapper;
using Domain.Models;
using Domain.Service.Admin.DTOs;
using Domain.Service.Admin.Interfaces;
using Domain.Service.Job.DTOs;
using HireMeNow_WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HireMeNow_WebApi.API.Admin
{
    /* [Route("api/[controller]")]*/
    [ApiController]
    public class AdminController : BaseApiController<AdminController> 
    {
        private readonly IAdminServices _adminService;
        private readonly IMapper _mapper;
        IAdminRepository _adminRepository;
        private IMapper mapper;


        public AdminController(IMapper mapper, IAdminServices adminService, IAdminRepository adminRepostory)
        {
            _mapper = mapper;
            _adminService = adminService;
            _adminRepository = adminRepostory;
        }
   
        [HttpGet]
        [Route("admin/GetJobSeekers")]
        public async Task<IActionResult> GetJobSeekers()
        {

            try
            {
               var jobSeekers = await _adminService.GetJobSeekers();
                return Ok(_mapper.Map<List<JobSeekerDto>>(jobSeekers));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("admin/GetCompanies")]
        public async Task<IActionResult> GetCompanies()
        {

            try
            {
                var jobProviders = await _adminService.GetCompanies();
                return Ok(_mapper.Map<List<JobProviderDto>>(jobProviders));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("admin/GetCompanyUsers")]
        public async Task<IActionResult> GetCompanyUsers()
        {

            try
            {
                var companyUsers = await _adminService.GetCompanyUsers();
                return Ok(_mapper.Map<List<CompanyUsersDto>>(companyUsers));
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("admin/RemoveCompanyUsers/{id}")]
        public IActionResult Remove(Guid id)
        {
            try
            {
                _adminService.DeleteById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        
        }

        [HttpDelete]
        [Route("admin/RemoveCompanies/{id}")]
        public IActionResult RemoveCompanies(Guid id)
        {
            try
            {
                _adminService.DeleteCompaniesById(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


        [HttpGet]
        [Route("admin/GetCompanyCount")]
        public IActionResult GetCompanyCount()
        {
            try
            {
                var count = _adminService.GetCompanyCount();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("admin/GetJobProviderCount")]
        public IActionResult GetJobProviderCount()
        {
            try
            {
                var count = _adminService.GetJobProviderCount();
                return Ok(new { Count = count });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }

    }

}
