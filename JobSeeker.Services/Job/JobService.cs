using AutoMapper;
using JobSeeker.DatabaseLayer.Models;
using JobSeeker.Messages;
using JobSeeker.Messages.RequestMessages;
using JobSeeker.Services.Interfaces.Job;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Services.Jobs
{
	public class JobService : ServiceBase, IJobService
	{
		private IMapper _mapper;

		public JobService(ApplicationDbContext context,
			IServiceProvider serviceProvider,
			IMapper mapper
			) : base(context, serviceProvider)
		{
			_mapper = mapper;
		}

		public async Task<List<JobMessage>> GetJobsAsync(JobSearchRequestMessage requestMessage)
		{
			var query = GenerateJobSearchQuery(requestMessage);

			var result = await query.Include(item => item.City)
				.Include(item => item.DictionaryEmploymentType)
				.Include(item => item.DictionaryJobCategory)
				.ToListAsync();

			return _mapper.Map<List<JobMessage>>(result);
		}

		private IQueryable<Job> GenerateJobSearchQuery(JobSearchRequestMessage requestMessage)
		{
			var query = Context.Job.Where(item => item.IsActive && !item.IsDeleted);

			if (requestMessage.CityIds.Any())
			{
				query = query.Where(item => requestMessage.CityIds.Contains(item.CityId));
			}

			if (requestMessage.CategoryIds.Any())
			{
				query = query.Where(item => requestMessage.CategoryIds.Contains(item.DictionaryJobCategoryId));
			}

			if (requestMessage.EmploymentIds.Any())
			{
				query = query.Where(item => requestMessage.EmploymentIds.Contains(item.DictionaryEmploymentTypeId));
			}

			return query;
		}
	}
}
