using LogChallenge.Application.Interfaces;
using LogChallenge.Infra.IoC;
using LogChallenge.UI.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LogChallenge.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILogApplication _LogApplication;

        public HomeController(ILogger<HomeController> logger, ILogApplication LogApplication)
        {
            _logger = logger;
            _LogApplication = LogApplication;
        }

        public async Task<IActionResult> Index()
        {                     
            var teste2 = await _LogApplication.List();
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
