using AutoMapper;
using JobSeeker.DatabaseLayer.Models;
using JobSeeker.Messages.DropDown;
using JobSeeker.ViewModels.DropDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobSeeker.Common
{
	public class AutoMapperProfileConfiguration : Profile
	{
		public AutoMapperProfileConfiguration()
		{
			CreateMap<City, DropDownMessage>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CityId))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.CityName));
			CreateMap<DictionaryJobCategory, DropDownMessage>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DictionaryJobCategoryId))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Category));
			CreateMap<DictionaryEmploymentType, DropDownMessage>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DictionaryEmploymentTypeId))
				.ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.EmploymentType));

			CreateMap<DropDownMessage, DropDownViewModel>();
		}
	}
}
