using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Movie
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Genre { get; set; }
        public int Release_Year { get; set; }
        public String Language { get; set; }
        public int Rental_Fee { get; set; }
        public String Description { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }

    }
}