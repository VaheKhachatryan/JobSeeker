using JobSeeker.Messages.DropDown;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Services.Interfaces.Cache
{
	public interface ICacheService
	{
		Task<List<DropDownMessage>> GetCitiesAsync();

		Task<List<DropDownMessage>> GetEmploymentTypesAsync();

		Task<List<DropDownMessage>> GetCategoriesAsync();
	}
}
