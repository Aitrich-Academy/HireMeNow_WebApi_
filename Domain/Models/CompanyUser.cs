using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public partial class CompanyUser
{
    public Guid Id { get; set; }
	[Required]
	[ForeignKey(nameof(CompanyNavigation))]
	public Guid? Company { get; set; }

    public virtual JobProviderCompany? CompanyNavigation { get; set; }

    public virtual ICollection<JobPost> JobPosts { get; set; } = new List<JobPost>();
		
}
