using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Job.DTOs
{

    public class JobPostsDtos
    {
        public Guid Id { get; set; }

        public string JobTitle { get; set; } = null!;

        public string JobSummary { get; set; } = null!;

        public string LocationName { get; set; }
        public string IndustryName { get;set; }
        public string JobCategoryName { get; set; }    

		public string PostedByNavigationFirstName { get; set;}

        public DateTime PostedDate { get; set; }

        public bool Saved { get; set; }

    }
}


/*
{
    "id": "f7c8130b-8e82-4f6a-ba36-5a4f2be33d8a",
  "jobTitle": "Python",
  "jobSummary": "Developer",
  "jobLocation": "3c47b95a-e1dc-4c08-9a41-89f48dc2761f",
  "company": "a267f149-3e97-4b70-9d11-5e17e8c36c87",
  "industry": "a5ec3040-31d2-4fb8-8ef4-7d93d857c86a",
  "postedBy": "f7c8130b-8e82-4f6a-ba36-5a4f2be33d8a",
  "postedDate": "2023-10-27T09:10:24.487Z"
}*/
