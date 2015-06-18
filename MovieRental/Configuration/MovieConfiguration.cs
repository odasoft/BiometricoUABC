using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Configuration
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            this.ToTable("Movie");
            this.Property(s => s.Name).IsRequired();
            this.Property(s => s.Genre).IsRequired();
            this.Property(s => s.Release_Year).IsRequired();
            this.Property(s => s.Rental_Fee).IsRequired();
            this.Property(s => s.Language).IsRequired();

        }
    }
}