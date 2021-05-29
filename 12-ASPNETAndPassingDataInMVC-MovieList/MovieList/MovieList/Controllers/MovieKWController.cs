using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieList.Models;

namespace MovieList.Controllers
{
    public class MovieKWController : Controller
    {
        private MovieContext context { get; set; }
        public MovieKWController(MovieContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("EditKW", new MovieKW());
        }
        [HttpGet]
        public IActionResult EditKW(int id)
        {
            ViewBag.Action = "EditKW";
            var movie = context.Movies.Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult EditKW(MovieKW movieKw)
        {
            if (ModelState.IsValid)
            {
                if (movieKw.MovieId == 0)
                    context.Movies.Add(movieKw);
                else
                    context.Movies.Update(movieKw);
                context.SaveChanges();
                return RedirectToAction("IndexKW", "HomeKW");
            }
            else
            {
                ViewBag.Action = (movieKw.MovieId == 0) ? "Add" : "EditKW";
                return View(movieKw);
            }
        }
        [HttpGet]
        public IActionResult DeleteKW(int id)
        {
            var movie = context.Movies.Find(id);
            return View(movie);
        }
        [HttpPost]
        public IActionResult DeleteKW(MovieKW movieKw)
        {
            context.Movies.Remove(movieKw);
            context.SaveChanges();
            return RedirectToAction("" +
                                    "Index" +
                                    "KW", "HomeKW");
        }
    }
}