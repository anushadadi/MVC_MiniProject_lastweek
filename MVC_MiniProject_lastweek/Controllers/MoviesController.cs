using MVC_MiniProject_lastweek.Models;
using MVC_MiniProject_lastweek.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MVC_MiniProject_lastweek.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _dbContext;
        public MoviesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Movies
         
        public ActionResult MoviesList()
        {
            var mov = _dbContext.movies.Include(m => m.Genre).ToList();
            //return View(mov);
            if (User.IsInRole(RoleNames.CanManageMovies))
                return View (mov);
            return View("ReadOnlyList",mov);
        }

        [Authorize(Roles =RoleNames.CanManageMovies)]
        public ActionResult CreateMovie()
        {
            var Genre = _dbContext.Genres.ToList();
            var viewmodel = new MoviesViewModel()
            {
                Movie=new Movie(),
                Genres = Genre
            };
            
            return View(viewmodel);
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovie(Movie movie)
        {
            movie.AddedDate = DateTime.Now;
            if (!ModelState.IsValid)
            {
                var view = new MoviesViewModel
                {
                    Movie = movie,
                    Genres = _dbContext.Genres.ToList(),
                };

            }
            if(movie.MovieId==0)
            {
                _dbContext.movies.Add(movie);
            }
            else
            {
                var mov = _dbContext.movies.SingleOrDefault(m => m.MovieId == movie.MovieId);
                mov.MovieName = movie.MovieName;
                mov.ReleaseDate = movie.ReleaseDate;
                mov.Genre = movie.Genre;
                mov.NumberInStock = movie.NumberInStock;
            }
            _dbContext.SaveChanges();
            return RedirectToAction("MoviesList", "Movies");
           
        }


        public ActionResult Edit(int Id)
        {
            var details = _dbContext.movies.FirstOrDefault(m => m.MovieId == Id);
            if (details == null)
            {
                return Content("Movie Not Found");
            }
            var viewmodel = new MoviesViewModel()
            {
                Movie = details,
                Genres = _dbContext.Genres.ToList()
            };
            return View("CreateMovie", viewmodel);
        }



        //get Details
        public ActionResult Details(int id)
        {
            var details = _dbContext.movies.Include(m=>m.Genre).FirstOrDefault(m => m.MovieId == id);
            if (details == null)
            {
                return Content("Movie Not Found");
            }
            else
                return View(details);
        }
    }
}




//list of movies
//public List<Movie> MovieList()
//{
//    var movie = new List<Movie>
//            {
//                new Movie{ MovieName = "Movie1",MovieId=1 },
//                new Movie{ MovieName = "Movie2",MovieId=2},
//                new Movie{ MovieName = "Movie3",MovieId=3 },
//                new Movie{ MovieName = "Movie4",MovieId=4 },
//                new Movie{ MovieName = "Movie5",MovieId=5 },
//                new Movie{ MovieName = "Movie6",MovieId=6 },
//                new Movie{ MovieName = "Movie7",MovieId=7 },

//            };
//    return (movie);
//}

//public ActionResult Edit(int id)
//{
//    return Content("Id:" + id);
//}
//public ActionResult Index(int? pageIndex, string sortBy)
//{
//    if (!pageIndex.HasValue)
//        pageIndex = 1;
//    if (sortBy == null)
//        sortBy = "Name";
//    return Content("pageIndex" + pageIndex, "SortBy" + sortBy);
//}