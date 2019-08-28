using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeker.ViewModels.Job
{
	public class JobViewModel
	{
		public int JobId { get; set; }
		public string Category { get; set; }
		public string EmploymentType { get; set; }
		public string City { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime PostedDate { get; set; }
	}
}
