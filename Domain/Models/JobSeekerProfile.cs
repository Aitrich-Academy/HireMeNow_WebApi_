using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class JobSeekerProfile
{
    [Key]
    public Guid Id { get; set; }

    public Guid ResumeId { get; set; }
    public Guid JobSeekerId { get; set; }

    public string? ProfileName { get; set; }

    public string? ProfileSummary { get; set; }

    public virtual Resume Resume { get; set; } = null!;

    public virtual JobSeeker JobSeeker { get; set; } 

    public List<JobSeekerProfileSkill> JobSeekerProfileSkills { get; set; }

    //public virtual ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();

    public virtual ICollection<WorkExperience> WorkExperiences { get; set; } = new List<WorkExperience>();
}
