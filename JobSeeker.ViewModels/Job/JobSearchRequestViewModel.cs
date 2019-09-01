using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeker.ViewModels.Jobs
{
	public class JobSearchRequestViewModel
	{
		public List<int> CityIds { get; set; }
		public List<int> CategoryIds { get; set; }
		public List<int> EmploymentIds { get; set; }

		public int? Start { get; set; }
		public int? End { get; set; }
		public string SearchKeyWord { get; set; }
	}
}
