using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
namespace OnlineStore.Models
{
    public class ViewModel
    {

        public string ToHumanDate(DateTime? date)
        {
            DateTime then = date ?? DateTime.Now;
            //return then.ToString("dddd, dd MMMM yyyy - hh:mm tt");
            //return then.ToString("dddd, dd MMMM yyyy"); 
            return then.ToString("dd/MM/yyyy");
        }

        public string FormattedAmount(decimal? amount)
        {
            decimal a = (decimal)amount;
            return a.ToString("N2", CultureInfo.InvariantCulture);
        }

        ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();

        public ViewModel()
        {
            CategoryMenu = db.Categories.ToList();
        }

        public List<Item> item { get; set; }
        public List<Item> item1 { get; set; }
        public List<Item> item2 { get; set; }

        public List<Category> ctgry { get; set; }

        //public List<Item> item { get; set; }
        public Item SingleItem { get; set; }
        public Category SingleCategory { get; set; }

        public List<Category> CategoryMenu { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<Item> Wishlist { get; set; }
        public decimal total { get; set; }
        public decimal discounted { get; set; }
        public int totalcount { get; set; }


        public string GetAvailability(string available)
        {
            if (available == "1")
                return "<span style=\"color:green\">In Stock</span>";
            else if (available == "2")
                return "<span style='color:red'>Out of Stock</span>";
            else if (available == "3")
                return "Awaiting Information";
            else
                return "Awaiting Information";
        }
    }
}