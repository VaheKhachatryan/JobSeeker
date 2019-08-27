using AutoMapper;
using JobSeeker.DatabaseLayer.Models;
using JobSeeker.Messages.DropDown;
using JobSeeker.Services.Interfaces.Cache;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Services.Cache
{
	public class CacheInitializerService : ICacheInitializerService
	{
		private ApplicationDbContext _context;
		private IMapper _mapper;

		public CacheInitializerService(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<List<DropDownMessage>> GetCities()
		{
			var cities = await _context.City.ToListAsync();
			return _mapper.Map<List<DropDownMessage>>(cities);
		}

		public async Task<List<DropDownMessage>> GetEmploymentTypes()
		{
			var employmentTypes = _context.DictionaryEmploymentType.ToList();
			return _mapper.Map<List<DropDownMessage>>(employmentTypes);
		}

		public async Task<List<DropDownMessage>> GetJobCategories()
		{
			var jobCategories = _context.DictionaryJobCategory.ToList();
			return _mapper.Map<List<DropDownMessage>>(jobCategories);
		}
	}
}
