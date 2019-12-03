using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MiniProject_lastweek.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name ="Customer Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name ="Date Of Birth")]
        [DataType(DataType.Date)]
        [DOBvalidation]
        public DateTime? DOB { get; set; }
        public bool IsSubsribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Required]
        public byte MembershipTypeId { get; set; }

    }
}