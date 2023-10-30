using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.DTOs
{
	public class AppliedJobsDtos
	{
		public AppliedJobsDtos()
		{
		}

		public AppliedJobsDtos(Guid id, JobPost jobPost)
		{
			Id = id;
			JobPost = jobPost;
		}

		public Guid Id { get; set; }
		public virtual JobPost JobPost { get; set; }
		public virtual JobProviderCompany Company { get; set; }	

	}
}
