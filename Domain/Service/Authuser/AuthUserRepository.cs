using AutoMapper;
using Domain.Models;
using Domain.Service.Authuser.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Authuser
{
    public class AuthUserRepository: IAuthUserRepository
    {
        protected readonly DbHireMeNowWebApiContext _context;
        IMapper mapper;
        public AuthUserRepository(DbHireMeNowWebApiContext dbContext,IMapper _mapper)
        {
            _context = dbContext;
            mapper=_mapper;
        }

        public async Task<AuthUser> AddAuthUser(AuthUser authUser)
        {
            //await _context.SystemUsers.AddAsync(authUser);
            await  _context.AuthUsers.AddAsync(authUser);
            Models.JobSeeker jobSeeker = mapper.Map<Models.JobSeeker>(authUser);
            await _context.JobSeekers.AddAsync(jobSeeker);
            _context.SaveChanges();
            return authUser;
        }
    }
}
