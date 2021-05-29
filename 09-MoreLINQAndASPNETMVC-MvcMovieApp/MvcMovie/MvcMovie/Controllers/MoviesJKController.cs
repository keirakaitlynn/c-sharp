using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class MoviesJKController : Controller
    {
        private readonly MvcMovieContext _context;

        public MoviesJKController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> IndexJK(string movieGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Movie 
                                            orderby m.Genre 
                                            select m.Genre;

            var movies = from m in _context.Movie 
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            var movieGenreVM = new MovieGenreViewModelJK
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }

        [HttpPost]
        public string IndexJK(string searchString, bool notUsed)
        {
            return "From [HttpPost]IndexJK: filter on " + searchString;
        }

        // GET: Movies/DetailsJK/5
        public async Task<IActionResult> DetailsJK(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/CreateJK
        public IActionResult CreateJK()
        {
            return View();
        }

        // POST: Movies/CreateJK
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJK([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] MovieJK movieJk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieJk);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexJK));
            }
            return View(movieJk);
        }

        // GET: Movies/EditJK/5
        public async Task<IActionResult> EditJK(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/EditJK/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditJK(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] MovieJK movieJk)
        {
            if (id != movieJk.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieJk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExistsJK(movieJk.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexJK));
            }
            return View(movieJk);
        }

        // GET: Movies/DeleteJK/5
        public async Task<IActionResult> DeleteJK(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/DeleteJK/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteJK(int id, bool notUsed)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexJK));
        }

        private bool MovieExistsJK(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
