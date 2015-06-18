using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Inventory
    {
        public int ID { get; set; }
        public int MovieID { get; set; }
        public int Stock { get; set; }

        public virtual Movie Movies { get; set; }
    }
}