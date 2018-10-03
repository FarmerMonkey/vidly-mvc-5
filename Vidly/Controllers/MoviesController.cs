using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var movies = _context.Movies.Include(c => c.Genre).ToList();

            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == Id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Id = 1, Name = "Shrek" },
                new Movie { Id = 2, Name = "Wall-E" }
            };
        }


        // GET: Movies/Random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            //return View(viewModel); // One method of passing data to the view, is via an argument, preferred way
            //behind the scenes, this uses:
            //viewResult.ViewData.Model


            //2nd method - View Dictionary
            /*
            ViewData["Movie"] = movie;
            return View();

            Downside to this method, (1) view code is ugly (must cast), and (2) view code is dependent on "magic string" of "Movie", makes code fragile
            */

            //3rd method -ViewBag, instead of "magic string", you have "magic object", still fragile
            //ViewBag.Movie = movie;
            //return View();

            return View(viewModel);
        }

        // Section 2: Lesson 13 - Using attribute routing w/ constraints
        /*
         * Other possible constraints include min, max, minlength, maxlength, int, float, guid
         * 
         */
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}