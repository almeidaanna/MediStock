﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FIT5032_MediStockContainer : DbContext
    {
        public FIT5032_MediStockContainer()
            : base("name=FIT5032_MediStockContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Logistic> Logistics { get; set; }
        public virtual DbSet<EquipmentBooking> EquipmentBookings { get; set; }
        public virtual DbSet<EquipmentRating> EquipmentRatings { get; set; }
        public virtual DbSet<ReturnImage> ReturnImages { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
    }
}
