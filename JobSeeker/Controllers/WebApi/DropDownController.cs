using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobSeeker.Services.Interfaces.Cache;
using JobSeeker.ViewModels.DropDown;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSeeker.Controllers.WebApi
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	[ApiController]
	public class DropDownController : ControllerBase
	{
		private ICacheService _cacheService { get; set; }
		private IMapper _mapper { get; set; }

		public DropDownController(ICacheService cacheService, IMapper mapper)
		{
			_cacheService = cacheService;
			_mapper = mapper;
		}
		
		[HttpGet]
		[Route("GetCities")]
		public async Task<List<DropDownViewModel>> GetCitiesAsync()
		{
			var result = await _cacheService.GetCitiesAsync();
			return _mapper.Map<List<DropDownViewModel>>(result);
		}

		[HttpGet]
		[Route("GetCategories")]
		public async Task<List<DropDownViewModel>> GetCategoriesAsync()
		{
			var result = await _cacheService.GetCategoriesAsync();
			return _mapper.Map<List<DropDownViewModel>>(result);
		}

		[HttpGet]
		[Route("GetEmploymentTypes")]
		public async Task<List<DropDownViewModel>> GetEmploymentTypesAsync()
		{
			var result = await _cacheService.GetEmploymentTypesAsync();
			return _mapper.Map<List<DropDownViewModel>>(result);
		}
	}
}