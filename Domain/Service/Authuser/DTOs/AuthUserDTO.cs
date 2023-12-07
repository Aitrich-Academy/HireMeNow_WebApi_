using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Authuser.DTOs
{
    public class AuthUserDTO
    {
        public string? UserName { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string Phone { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
