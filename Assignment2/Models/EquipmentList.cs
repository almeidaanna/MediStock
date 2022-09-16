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
    
    public partial class EquipmentList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EquipmentList()
        {
            this.EquipmentBookings = new HashSet<EquipmentBooking>();
        }
    
        public int equipment_id { get; set; }
        public int available_stock { get; set; }
        public int owner_id { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual Doctor Doctor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EquipmentBooking> EquipmentBookings { get; set; }
    }
}
