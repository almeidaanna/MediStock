//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class EquipmentBooking
    {
        public int Id { get; set; }
        [Display(Name = "Booking Date")]
        public System.DateTime datetime { get; set; }
        public bool status { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        [Range(1, 100)]
        public int quantity { get; set; }
        public int DoctorId { get; set; }
        public int LogisticId { get; set; }
        [Required]
        [Range(1, 100)]
        [Display(Name = "Equipment Number")]
        public int EquipmentId { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Logistic Logistic { get; set; }
        public virtual Equipment Equipment { get; set; }
    }
}
