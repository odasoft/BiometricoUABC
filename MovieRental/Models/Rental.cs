using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Rental
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }
        public int MovieID { get; set; }
        public DateTime Rental_Date { get; set; }
        public DateTime Due_Date { get; set; }
        public int Overdue_Fee { get; set; }

        public virtual Customer Customers { get; set; }
        public virtual Movie Movies { get; set; }
    }
}