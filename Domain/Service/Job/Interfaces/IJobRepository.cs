using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.Interfaces
{
	public interface IJobRepository
	{
		Task< List<SavedJob>> GetAllSavedJobsOfSeeker(Guid seekerId);
	}
}
