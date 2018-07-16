using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovies(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return movieInDb;
        }

        [HttpPost]
        public Movie CreateMovies(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);              
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        [HttpDelete]
        public String DeleteMovies(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return "Deleted Succesfully";
        }
        [HttpPut]
        public void UpdateMovies(int id,Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.GenreId = movie.GenreId;

            _context.SaveChanges();
        }
    }
}
