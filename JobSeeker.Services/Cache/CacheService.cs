using JobSeeker.Messages.DropDown;
using JobSeeker.Messages.Enums;
using JobSeeker.Services.Interfaces.Cache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VeroxTech.Services.Interfaces.Cache;

namespace JobSeeker.Services.Cache
{
	public class CacheService : ICacheService
	{
		private ICacheInitializerService _cacheInitializerService;
		private ICacheManager _cacheManager;

		public CacheService(ICacheInitializerService cacheInitializerService, ICacheManager cacheManager)
		{
			_cacheInitializerService = cacheInitializerService;
			_cacheManager = cacheManager;
		}

		public async Task<List<DropDownMessage>> GetCitiesAsync()
		{
			return await _cacheManager.GetAsync<List<DropDownMessage>>(CacheEnum.City.ToString(), _cacheInitializerService.GetCities);
		}

		public async Task<List<DropDownMessage>> GetEmploymentTypesAsync()
		{
			return await _cacheManager.GetAsync<List<DropDownMessage>>(CacheEnum.EmploymentType.ToString(), _cacheInitializerService.GetEmploymentTypes);
		}

		public async Task<List<DropDownMessage>> GetCategoriesAsync()
		{
			return await _cacheManager.GetAsync<List<DropDownMessage>>(CacheEnum.Category.ToString(), _cacheInitializerService.GetJobCategories);
		}
	}
}
