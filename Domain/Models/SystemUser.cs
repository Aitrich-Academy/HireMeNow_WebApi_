using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class SystemUser
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Role { get; set; }

    public virtual AuthUser? AuthUserIdNavigation { get; set; }

    public virtual ICollection<AuthUser> AuthUserSystemUsers { get; set; } = new List<AuthUser>();

    public virtual JobSeeker? JobSeeker { get; set; }
}
