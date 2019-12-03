using MVC_MiniProject_lastweek.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MiniProject_lastweek.dtos
{
    public class MoviesDto
    {
        public int MovieId { get; set; }
        [Required]
      
        public string MovieName { get; set; }
  
        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public DateTime AddedDate { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        //[Range(1, 20)]

        public int NumberInStock { get; set; }
    }
}