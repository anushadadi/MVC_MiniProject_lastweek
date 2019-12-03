using MVC_MiniProject_lastweek.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_MiniProject_lastweek.ViewModel
{
    public class CustomerViewModel
    {
        public List<MembershipType> MembershipTypes { get; set; }
        public Customer customer { get; set; }
    }
}