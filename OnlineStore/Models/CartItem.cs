using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ImageURL { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string Availability { get; set; }
        public int Quantity { get; set; }
    }
}