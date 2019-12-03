using MVC_MiniProject_lastweek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_MiniProject_lastweek.ViewModel
{
    public class MoviesViewModel
    {
        public List<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}