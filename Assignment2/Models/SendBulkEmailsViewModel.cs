using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class SendBulkEmailsViewModel
    {
        [Display(Name = "Email address")]
        public List<String> ToEmails { get; set; }
        [Required(ErrorMessage = "Please enter a subject.")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please enter the email content")]
        public string Contents { get; set; }

        public HttpPostedFileBase PathToFile { get; set; }
    }
}