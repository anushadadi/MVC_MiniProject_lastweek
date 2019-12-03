using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_MiniProject_lastweek.Models
{
    public class DOBvalidation:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.PayAsYouGo|| customer.MembershipTypeId == MembershipType.Unknown)

                return ValidationResult.Success;

            if (customer.DOB == null)

                return new ValidationResult("BirthDate is required.");

            var age = DateTime.Today.Year - customer.DOB.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should atleast have 18 years to have a Membership");

        }
    }
}