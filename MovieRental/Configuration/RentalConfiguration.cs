using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Configuration
{
    public class RentalConfiguration : EntityTypeConfiguration<Rental>
    {
        public RentalConfiguration()
        {
            this.ToTable("Rental");
            this.Property(s => s.CustomerID).IsRequired();
            this.Property(s => s.MovieID).IsRequired();
            this.Property(s => s.Rental_Date).HasColumnName("Rental_Date").HasColumnType("datetime2").IsRequired();//.HasColumnType("datetime1").IsRequired();
            this.Property(s => s.Due_Date).HasColumnName("Due_Date").HasColumnType("datetime2").IsRequired();//.HasColumnType("datetime1").IsRequired();
           // this.HasMany<Rental>(c => c.).WithRequired(s => s.CustomerID).HasForeignKey(s => s.CustomerID);
            this.HasRequired<Movie>(s=>s.Movies).WithMany(s => s.Rental).HasForeignKey(s => s.MovieID);
            this.HasRequired<Customer>(s => s.Customers).WithMany(s => s.Rentals).HasForeignKey(s => s.CustomerID);
        }
    }
}