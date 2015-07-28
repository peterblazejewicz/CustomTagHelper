using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CustomTagHelper.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomTagHelper.Controllers
{
    public class MoviesController : Controller
    {
        private MovieService _moviesService;

        public MoviesController(MovieService moviesService)
        {
            _moviesService = moviesService;
        }

        // Sample exhibiting the use of nested cache tag helpers with custom user expiration triggers.
        // Trigger expirations cascade, expiration of the inner tag helper's content either due to absolute or sliding
        // expiration or due to a user specified expiration trigger would cause the outer cache tag helper to also expire.
        public ViewResult Index()
        {
            ViewData["Title"] = "Movies";
            return View();
        }

        [HttpPost]
        public ViewResult UpdateMovieRatings()
        {
            _moviesService.UpdateMovieRating();

            ViewData["Title"] = "Movies with updated ratings";
            return View("Index");
        }

        [HttpPost]
        public ViewResult UpdateCriticsQuotes()
        {
            _moviesService.UpdateCriticsQuotes();

            ViewData["Title"] = "Movies with updated critics quotes";
            return View("Index");
        }

    }
}
