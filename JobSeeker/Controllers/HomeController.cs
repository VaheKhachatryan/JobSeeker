using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JobSeeker.Models;
using JobSeeker.Services.Interfaces.Cache;

namespace JobSeeker.Controllers
{
	public class HomeController : Controller
	{
		private ICacheInitializerService _cacheInitializerService;
		public HomeController(ICacheInitializerService cacheInitializerService)
		{
			_cacheInitializerService = cacheInitializerService;
		}

		public async Task<IActionResult> Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
