﻿namespace HireMeNow_WebApi.API.JobProvider.RequestObjects
{
	public class AddCompanyRequestobject
	{
		
		public string LegalName { get; set; } = null!;

		public string Summary { get; set; } = null!;

		public Guid Industry { get; set; }

		public string Email { get; set; } = null!;

		public long Phone { get; set; }

		public string Address { get; set; } = null!;

		public string Website { get; set; } = null!;

		public Guid Location { get; set; }


	}
}
