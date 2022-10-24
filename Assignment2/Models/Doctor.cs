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

    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            this.EquipmentBookings = new HashSet<EquipmentBooking>();
            this.EquipmentRatings = new HashSet<EquipmentRating>();
        }
    
        public int Id { get; set; }
        [Display (Name = "Doctor Name")]
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone_no { get; set; }
        public Nullable<decimal> latitude { get; set; }
        public string hospital_name { get; set; }
        public string email_address { get; set; }
        public string password { get; set; }
        public Nullable<decimal> longitude { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentBooking> EquipmentBookings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentRating> EquipmentRatings { get; set; }
    }
}
