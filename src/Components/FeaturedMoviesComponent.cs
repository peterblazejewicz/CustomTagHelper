using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Caching;
using Microsoft.Framework.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomTagHelper.Services;
using CustomTagHelper.Models;

namespace CustomTagHelper.Components
{
    [ViewComponent(Name = "FeaturedMovies")]
    public class FeaturedMoviesComponent : ViewComponent
    {
        private readonly IMemoryCache _cache;
        private readonly MovieService _movieService;

        public FeaturedMoviesComponent(MovieService movieService, IMemoryCache cache)
        {
            _movieService = movieService;
            _cache = cache;
        }

        public IViewComponentResult Invoke()
        {
            // Since this component is invoked from within a CacheTagHelper,
            // cache the movie list and provide an expiration trigger, which when triggered causes the
            // CacheTagHelper's cached data to be invalidated.
            var cacheKey = "featured_movies";
            IEnumerable<FeaturedMovie> movies;
            if (!_cache.TryGetValue(cacheKey, out movies))
            {
                IExpirationTrigger trigger;
                movies = _movieService.GetFeaturedMovie(out trigger);
                _cache.Set(cacheKey, movies, new MemoryCacheEntryOptions().AddExpirationTrigger(trigger));
            }
            return View(movies);
        }

        public IViewComponentResult Invoke(string movieName)
        {
            string quote;
            if (!_cache.TryGetValue(movieName, out quote))
            {
                IExpirationTrigger trigger;
                quote = _movieService.GetCriticsQuote(out trigger);
                _cache.Set(movieName, quote, new MemoryCacheEntryOptions().AddExpirationTrigger(trigger));
            }
            return Content(quote);
        }
    }
}
