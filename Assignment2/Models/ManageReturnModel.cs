using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Assignment2.Models
{
    public partial class ManageReturnModel : DbContext
    {
        public ManageReturnModel()
            : base("name=ManageReturnModel")
        {
        }

        public virtual DbSet<ReturnImage> ReturnImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReturnImage>()
                .Property(e => e.Path)
                .IsUnicode(false);

            modelBuilder.Entity<ReturnImage>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}
