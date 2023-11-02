using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

public partial class JobPost
{
    public Guid Id { get; set; }

    public string JobTitle { get; set; } = null!;

    public string JobSummary { get; set; } = null!;

    public Guid JobLocation { get; set; }

 
    public Guid Company { get; set; }

    public Guid Category { get; set; }

    public Guid Industry { get; set; }
	[ForeignKey(nameof(PostedByNavigation))]
	public Guid PostedBy { get; set; }

    public DateTime PostedDate { get; set; }

    public virtual Location JobLocationNavigation { get; set; } = null!;

    public virtual ICollection<JobResponsibility> JobResponsibilities { get; set; } = new List<JobResponsibility>();

	public virtual CompanyUser PostedByNavigation { get; set; } = null!;

    //public virtual ICollection<Skill> Skills { get; set; } = new List<Skill>();
}
