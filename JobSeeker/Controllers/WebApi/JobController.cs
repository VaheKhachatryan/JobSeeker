using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobSeeker.Messages.RequestMessages;
using JobSeeker.Services.Interfaces.Job;
using JobSeeker.ViewModels.Job;
using JobSeeker.ViewModels.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSeeker.Controllers.WebApi
{
	[Route("api/[controller]")]
	[ApiController]
	[Produces("application/json")]
	public class JobController : ControllerBase
	{
		private IJobService _jobService;
		private IMapper _mapper;

		public JobController(IJobService jobService,
			IMapper mapper)
		{
			_jobService = jobService;
			_mapper = mapper;
		}

		[Route("GetJobs")]
		[HttpPost]
		public async Task<List<JobViewModel>> GetJobsAsync([FromBody] JobSearchRequestViewModel request)
		{
			var result = await _jobService.GetJobsAsync(_mapper.Map<JobSearchRequestMessage>(request));
			return _mapper.Map<List<JobViewModel>>(result);
		}
	}
}