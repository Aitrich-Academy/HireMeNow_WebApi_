

using Domain.Models;

namespace HireMeNow_WebApi.API.Job.SavedJobObjects
{
	public class SavedJobObjects

	{
		public Guid Job { get; set; }
		public DateTime DateSaved { get; set; }
		public  JobPost JobPost { get; set; }

	}
}
