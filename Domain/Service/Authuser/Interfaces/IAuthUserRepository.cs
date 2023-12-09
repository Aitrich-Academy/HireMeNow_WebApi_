using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Authuser.Interfaces
{
    public interface IAuthUserRepository
    {
        Task<AuthUser> AddAuthUser(AuthUser authUser);

        Task<AuthUser> AddAuthUserJP(AuthUser authUser);
        string? CreateToken(AuthUser user);
        CompanyUser GetUser(Guid userid);

	}
}
