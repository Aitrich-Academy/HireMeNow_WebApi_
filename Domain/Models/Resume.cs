using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Resume
{
    public Guid Id { get; set; }

    public string? Title { get; set; }

    public byte[]? File { get; set; }

    public virtual ICollection<JobSeekerProfile> JobSeekerProfiles { get; set; } = new List<JobSeekerProfile>();
}
