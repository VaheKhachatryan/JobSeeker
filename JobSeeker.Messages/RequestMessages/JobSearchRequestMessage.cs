using System;
using System.Collections.Generic;
using System.Text;

namespace JobSeeker.Messages.RequestMessages
{
	public class JobSearchRequestMessage
	{
		public List<int> CityIds { get; set; }
		public List<int> CategoryIds { get; set; }
		public List<int> EmploymentIds { get; set; }

		public string SearchKeyWord { get; set; }
	}
}
