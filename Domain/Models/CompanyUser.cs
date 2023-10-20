using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CompanyUser
{
    public Guid Id { get; set; }

    public Guid? Company { get; set; }

    public virtual JobProviderCompany? CompanyNavigation { get; set; }

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
}
