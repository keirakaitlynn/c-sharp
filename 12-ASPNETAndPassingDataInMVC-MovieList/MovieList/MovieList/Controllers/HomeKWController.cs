using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieList.Models;

namespace MovieList.Controllers
{
    public class HomeKWController : Controller
    {
        private MovieContext context { get; set; }
        public HomeKWController(MovieContext ctx)
        {
            context = ctx;
        }
        public IActionResult IndexKW()
        {
            var movies = context.Movies.OrderBy(m => m.Name).ToList();
            return View(movies);
        }

    }
}