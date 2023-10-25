using Domain.Helpers;

namespace Domain.Helpers
{
	public class JobListParams: PaginationParams
	{
		public Guid UserId { get; set; } 
		
	}
}
