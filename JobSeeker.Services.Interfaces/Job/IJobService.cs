using JobSeeker.Messages;
using JobSeeker.Messages.RequestMessages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Services.Interfaces.Job
{
	public interface IJobService
	{
		Task<List<JobMessage>> GetJobsAsync(JobSearchRequestMessage requestMessage);
	}
}
