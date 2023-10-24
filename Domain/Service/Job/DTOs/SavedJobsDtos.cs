using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.DTOs
{
	public class SavedJobsDtos
	{
		[Required]
		public Guid Job { get; set; }

		[Required]
		public Guid SavedBy { get; set; }

	}
}
