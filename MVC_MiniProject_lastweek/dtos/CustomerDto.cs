using MVC_MiniProject_lastweek.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MiniProject_lastweek.dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }

       
        //[DOBvalidation]
        public DateTime? DOB { get; set; }
        public bool IsSubsribedToNewsLetter { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        
        public byte MembershipTypeId { get; set; }
    }
}