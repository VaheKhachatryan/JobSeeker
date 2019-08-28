using JobSeeker.DatabaseLayer.Models;
using JobSeeker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JobSeeker.Services
{
	public class ServiceBase : IServiceBase, IDisposable
	{
		private bool _disposed;

		public ServiceBase(ApplicationDbContext context,
			IServiceProvider serviceProvider
		  )
		{
			Context = context;
			ServiceProvider = serviceProvider;
		}

		public async Task<bool> CommitToDatabase(CancellationToken cancellationToken = default(CancellationToken))
		{
			return await Context.SaveChangesAsync(cancellationToken) > 0;
		}

		protected ApplicationDbContext Context { get; set; }
		protected IServiceProvider ServiceProvider { get; set; }

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_disposed)
			{
				Context?.Dispose();
			}
			_disposed = true;
		}
	}
}
