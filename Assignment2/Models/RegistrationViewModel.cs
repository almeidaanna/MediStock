using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Assignment2.Models
{
    public class RegistrationViewModel
    {
        [Required(ErrorMessage = "First Name can not be empty")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        
        [RegularExpression(@"^[a-zA-Z0-9._%+]+@[a-zA-Z0-9.]+")]
        [Required(ErrorMessage = "Enter a Valid Email Address")]
        [EmailAddress]
        [Display(Name = "Email ID")]
        public string Email { get; set; }

        [RegularExpression(@"^(?:\+?(61))? ?(?:\((?=.*\)))?(0?[2-57-8])\)? ?(\d\d(?:[- ](?=\d{3})|(?!\d\d[- ]?\d[- ]))\d\d[- ]?\d[- ]?\d{3})$")]
        [Required(ErrorMessage = "Enter a Valid Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password can not be empty")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "Role")]
        public RoleList Role { get; set; }

       

        [Display(Name = "Medical Registration")]
        public string MedicalRegistration { get; set; }
        
        [Display(Name = "Facility Name")]
        public string FacilityName { get; set; }

        
        [Display(Name = "Facility Address")]
        public string Location { get; set; }



        //protected void RoleList_Change(object sender, EventArgs e)
        //{
        //    if (Role.Equals("Doctor") || Role.Equals("Admin"))
        //    {
        //        MedicalRegistration.Visible = true;
        //        FacilityName.Visible = true;
        //        Location.Visible = true;

        //    }
        //    else
        //    {
        //        MedicalRegistration.Visible = false;
        //        FacilityName.Visible = false;
        //        Location.Visible = false;
        //   }
        //}
    }
    public enum RoleList
    {
        Admin,
        Doctor,
        Logistics
    }
    
}