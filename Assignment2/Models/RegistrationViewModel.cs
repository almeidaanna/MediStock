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

        [Required(ErrorMessage = "Email can not be empty")]
        [EmailAddress]
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
        //    if (Role.Equals("Doctor") || Role.Equals("Pharmacist"))
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
        Pharmacist,
        Logistics
    }
    
}