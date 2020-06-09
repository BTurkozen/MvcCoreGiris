using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcCoreGiris.Interfaces;
using MvcCoreGiris.Models;
using MvcCoreGiris.Services;

namespace MvcCoreGiris.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LukyNumberService _lukyNumberService;
        public HomeController(ILogger<HomeController> logger, LukyNumberService lukyNumberService)
        {
            _logger = logger;
            _lukyNumberService = lukyNumberService;

        }

        public IActionResult Index()
        {
            ViewBag.SansliSayi = _lukyNumberService.LukyNumber;
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
