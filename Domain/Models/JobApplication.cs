using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Models
{
    public class JobApplication
    {
        public Guid Id { get; set; }

		[Required]
        [ForeignKey(nameof(JobPost))]
        public Guid JobPost_id {  get; set; }
        [ForeignKey(nameof(Applicant))]
        public Guid Applicant { get; set; }

        [ForeignKey(nameof(Resume))]
        public Guid Resume_id { get; set; }

        public string CoverLetter { get; set; }

        public DateTime Datesubmitted { get; set; }
        public string status { get; set; }

		public virtual JobPost? JobPost { get; set; }
		public virtual JobSeeker JobSeeker { get; set; }
        public virtual Resume Resume { get; set; }
        public virtual JobSeeker Seeker { get; set; }
        public virtual JobPost JobPost { get; set; }
    }
}
