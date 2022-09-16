using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class RegistrationViewModel
    {
    }
    public class FormOneViewModel
    {
        [Required(ErrorMessage = "First Name can not be empty")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email ID")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Email can not be empty")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Must match password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Display(Name = "Medical Registration")]
        public string MedicalRegistration { get; set; }
        
        [Display(Name = "Facility Name")]
        public string FacilityName { get; set; }

        [Display(Name = "Facility Address")]
        public string Location { get; set; }
    }
}