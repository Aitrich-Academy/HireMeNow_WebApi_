﻿using Domain.Service.Authuser.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Service.Authuser
{
	public class AuthUserService:IAuthUserService
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public string GetUserId()
		{
			var result = string.Empty;
			if (_httpContextAccessor.HttpContext != null)
			{
				result = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Sid).ToString();
			}
			return result;
		}
	}
}