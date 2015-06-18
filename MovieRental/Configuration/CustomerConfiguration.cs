using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration;
using Models;

namespace Configuration
{
    public class CustomerConfiguration:EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            this.ToTable("Customer");
            this.Property(p => p.FirstName).IsRequired();
            this.Property(p => p.LastName).IsRequired();
            this.Property(p => p.Email).IsRequired();
        }
    }
}