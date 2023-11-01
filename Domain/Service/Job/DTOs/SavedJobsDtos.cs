using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Service.Job.DTOs
{
	public class SavedJobsDtos
	{
		public SavedJobsDtos( DateTime dateSaved,JobPost jobpost)
		{
			
			DateSaved = dateSaved;
			JobPost = jobpost;
			
		}

	
		public DateTime DateSaved { get; set; }
		public virtual JobPost JobPost { get; set; }




	}
}
