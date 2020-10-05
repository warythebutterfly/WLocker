using System;
using System.Collections.Generic;

namespace OnlineStore.Models
{
    public partial class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string ImageURL { get; set; }
        public string ItemDescription { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public Nullable<System.DateTime> DateAdded { get; set; }
        public string Availability { get; set; }
    }
}
