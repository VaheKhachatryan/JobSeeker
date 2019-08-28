using AutoMapper;
using JobSeeker.DatabaseLayer.Models;
using JobSeeker.Messages;
using JobSeeker.Messages.DropDown;
using JobSeeker.Messages.RequestMessages;
using JobSeeker.ViewModels.DropDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSeeker.ViewModels.Jobs;
using JobSeeker.ViewModels.Job;

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
			CreateMap<JobSearchRequestViewModel, JobSearchRequestMessage>();
			CreateMap<JobMessage, JobViewModel>();

			CreateMap<Job, JobMessage>()
				.ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.CityName))
				.ForMember(dest => dest.EmploymentType, opt => opt.MapFrom(src => src.DictionaryEmploymentType.EmploymentType))
				.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.DictionaryJobCategory.Category))
				.ForMember(dest => dest.PostedDate, opt => opt.MapFrom(src => src.CreatedDate));
		}
	}
}
