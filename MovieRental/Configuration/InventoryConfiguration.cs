using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Configuration
{
    public class InventoryConfiguration : EntityTypeConfiguration<Inventory>
    {
        public InventoryConfiguration()
        {
            this.ToTable("Inventory");
            this.Property(s => s.Stock).IsRequired();
            this.Property(s => s.MovieID).IsRequired();
            this.HasRequired<Movie>(s => s.Movies).WithMany(s => s.Inventory).HasForeignKey(s => s.MovieID);

        }
    }
}