using AutoMapper;
using MVC_MiniProject_lastweek.dtos;
using MVC_MiniProject_lastweek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace MVC_MiniProject_lastweek.Controllers.api
{
    public class MovieDtoController : ApiController
    {
        private ApplicationDbContext _context;
        public MovieDtoController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<MoviesDto> GetMovies()
        {
            return _context.movies.Include(m=>m.Genre).ToList().Select(Mapper.Map<Movie, MoviesDto>);

        }

        
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.movies.SingleOrDefault(m => m.MovieId == id);
            if (movie == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(Mapper.Map<Movie, MoviesDto>(movie));
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MoviesDto moviesDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movie = Mapper.Map<MoviesDto, Movie>(moviesDto);
            _context.movies.Add(movie);
            _context.SaveChanges();
            moviesDto.MovieId = movie.MovieId;
            return Created(new Uri(Request.RequestUri + "/" + movie.MovieId), moviesDto);
        }

        [HttpPut]
        public void UpateMovie(int id, MoviesDto moviedto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var MvieInDb = _context.movies.SingleOrDefault(c => c.MovieId == id);
            if (MvieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //CustInDb.CustomerName = customer.CustomerName;
            //CustInDb.DOB = customer.DOB;
            //CustInDb.IsSubsribedToNewsLetter = customer.IsSubsribedToNewsLetter;
            //CustInDb.MembershipTypeId = customer.MembershipTypeId;

            Mapper.Map(moviedto,MvieInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var customerInDb = _context.movies.SingleOrDefault(m => m.MovieId == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.movies.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
