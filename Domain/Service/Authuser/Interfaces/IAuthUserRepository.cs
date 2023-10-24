﻿using Domain.Models;
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
        string? CreateToken(AuthUser user);
    }
}