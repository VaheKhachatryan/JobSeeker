using Autofac;
using Autofac.Extensions.DependencyInjection;
using JobSeeker.Services.Cache;
using JobSeeker.Services.Interfaces.Cache;
using JobSeeker.Services.Interfaces.Job;
using JobSeeker.Services.Jobs;
using Microsoft.Extensions.DependencyInjection;
using VeroxTech.Services.Cache;
using VeroxTech.Services.Interfaces.Cache;

namespace JobSeeker
{
	public static class Bootstrap
	{
		public static void ConfigureServiceDependencies(IServiceCollection services, ContainerBuilder builder)
		{
			builder.RegisterType<CacheInitializerService>().As<ICacheInitializerService>();
			builder.RegisterType<CacheService>().As<ICacheService>();
			builder.RegisterType<MemoryCacheManager>().As<ICacheManager>();
			builder.RegisterType<JobService>().As<IJobService>();

			builder.Populate(services);
		}
	}
}
