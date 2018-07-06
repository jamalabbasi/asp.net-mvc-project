using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Index()
        {
            var movies = new List<Movie>
             {
                 new Movie {Name="movie 1" },
                 new Movie {Name="movie 2" }
             };
            var viewModel = new IndexMovieViewModel
            {
                Movie = movies
            };
            return View(viewModel);
        } 
    }
}