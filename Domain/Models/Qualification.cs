using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Qualification
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid? JobseekerProfileId { get; set; }

    public Guid? JobPostId { get; set; }

    public virtual JobPost? JobPost { get; set; }
}
