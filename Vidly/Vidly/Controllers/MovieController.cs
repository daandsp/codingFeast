using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{

    public class MovieController : Controller
    {


        //Setting Database things :)
        private ApplicationDbContext _context;


        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }










        //View controls
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre);

            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole(RoleName.CanManageMovies))
                {
                    return View("Index", movies);
                }
            }

            return View("ReadOnlyIndex", movies);
        }


        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            
            return View("Details", movie);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public IActionResult Remove(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }










        //Adding, Updating and Deleting movies in Database
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Movie movie)
        {
            // Check ModelState Errors
            var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));

            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToRoute(new { controller = "Movie", action = "Details", id = movie.Id });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Movie movie)
        {
            if (movie.Id == 0)
            {
                return NotFound();
            }

            if (movie != null)
            {
                _context.Movies.Remove(movie);
            }
            _context.SaveChanges();

            return RedirectToRoute(new { controller = "Movie", action = "Index" });
        }










        // Non important things
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!", Id = 12 };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1", Id = 846},
                new Customer {Name = "Customer 2", Id = 345},
                new Customer {Name = "Customer 3", Id = 12}
            };

            var viewmodel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewmodel);
        }


        [Route("Movie/released/{year:int:minlength(4):maxlength(4)}/{month:int:minlength(2):maxlength(2):range(1, 12)}")]
        public IActionResult Released(int year, int month)
        {
            var date = new Date()
            {
                Year = year,
                Month = month
            };
            return View(date);
        }
    }
}
