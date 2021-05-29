using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Controllers
{
    public class HomeJKController : Controller
    {
        private readonly ILogger<HomeJKController> _logger;

        public HomeJKController(ILogger<HomeJKController> logger)
        {
            _logger = logger;
        }

        public IActionResult IndexJK()
        {
            return View();
        }

        public IActionResult PrivacyJK()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult ErrorJK()
        {
            return View(new ErrorViewModelJK { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
