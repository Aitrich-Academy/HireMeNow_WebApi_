using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.Models
{
	public class JobApplication
	{
		public Guid Id { get; set; }

		[Required]
		[ForeignKey(nameof(JobPost))]
		public Guid Job { get; set; }
		[Required]
		[ForeignKey(nameof(JobSeeker))]
		public Guid Applicant { get; set; }
		[Required]
		[ForeignKey(nameof(Resume))]
		public Guid resume { get; set; }
		public string CoverLetter { get; set; }
		public DateTime DateSubmitterd { get;set; }
		public Status JobApplicationStatus { get; set; }

		public virtual JobPost? JobPost { get; set; }
		public virtual JobSeeker JobSeeker { get; set; }
		public virtual Resume Resume { get; set; }
	}
}
