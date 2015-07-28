using CustomTagHelper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.Framework.Caching;

namespace CustomTagHelper.Services
{
    public class MovieService
    {
        private readonly Random _random = new Random();
        private CancellationTokenSource _FeaturedMovieTokenSource;
        private CancellationTokenSource _quotesTokenSource;

        public string GetCriticsQuote(out IExpirationTrigger trigger)
        {
            _quotesTokenSource = new CancellationTokenSource();

            var quotes = new[]
            {
                "A must see for iguana lovers everywhere",
                "Slightly better than watching paint dry",
                "Never felt more relieved seeing the credits roll",
                "Bravo!"
            };

            trigger = new CancellationTokenTrigger(_quotesTokenSource.Token);
            return quotes[_random.Next(0, quotes.Length)];
        }

        public IEnumerable<FeaturedMovie> GetFeaturedMovie(out IExpirationTrigger expirationTrigger)
        {
            _FeaturedMovieTokenSource = new CancellationTokenSource();
            expirationTrigger = new CancellationTokenTrigger(_FeaturedMovieTokenSource.Token);
            return GetMovies().OrderBy(m => m.Rank).Take(2);
        }

        public void UpdateCriticsQuotes()
        {
            _quotesTokenSource.Cancel();
            _quotesTokenSource.Dispose();
            _quotesTokenSource = null;
        }

        public void UpdateMovieRating()
        {
            _FeaturedMovieTokenSource.Cancel();
            _FeaturedMovieTokenSource.Dispose();
            _FeaturedMovieTokenSource = null;
        }

        private IEnumerable<FeaturedMovie> GetMovies()
        {
            yield return new FeaturedMovie { Name = "A day in the life of a blue whale", Rank = _random.Next(1, 10) };
            yield return new FeaturedMovie { Name = "FlashForward", Rank = _random.Next(1, 10) };
            yield return new FeaturedMovie { Name = "Frontier", Rank = _random.Next(1, 10) };
            yield return new FeaturedMovie { Name = "Attack of the space spiders", Rank = _random.Next(1, 10) };
            yield return new FeaturedMovie { Name = "Rift 3", Rank = _random.Next(1, 10) };
        }
    }
}
