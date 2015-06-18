using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Customer
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
}