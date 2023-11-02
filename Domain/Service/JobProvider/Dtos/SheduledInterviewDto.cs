using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider.Dtos
{
	public class SheduledInterviewDto
	{
		public JobProviderCompany Company { get; set; }
		public Guid Id { get; set; }
		public JobInterviewStatus Status { get; set; }
		public virtual Models.JobSeeker Jobseeker { get; set; }
		public virtual JobPost? Job { get; set; }
		public virtual CompanyUser? CompanyUser { get; set; }
	}
}
