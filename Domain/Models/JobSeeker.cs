using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class JobSeeker
{
    public Guid Id { get; set; }

    public string? UserName { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Phone { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Role { get; set; }

    public virtual SystemUser IdNavigation { get; set; } = null!;
}
