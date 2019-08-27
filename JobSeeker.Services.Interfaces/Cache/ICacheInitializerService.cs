using JobSeeker.Messages.DropDown;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSeeker.Services.Interfaces.Cache
{
	public interface ICacheInitializerService
	{
		Task<List<DropDownMessage>> GetCities();

		Task<List<DropDownMessage>> GetEmploymentTypes();

		Task<List<DropDownMessage>> GetJobCategories();
	}
}
