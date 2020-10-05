using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models;
namespace OnlineStore.Controllers
{
    public class WishlistController : Controller
    {
        public JsonResult Add(int ItemId)
        {

            try
            {
                ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
                var Item = db.Items.Where(a => a.ID == ItemId).FirstOrDefault();

                

                if (Session["Wishlist"] == null)
                {
                    List<Item> Wishlist = new List<Item>();
                    Wishlist.Add(Item);

                    Session["Wishlist"] = Wishlist;
                }
                else
                {
                    List<Item> Wishlist = (List<Item>)Session["Wishlist"];
                    Wishlist.Add(Item);

                    Session["Wishlist"] = Wishlist;
                }

                return Json(Item.Name);
            }
            catch (Exception ex)
            {
                return Json("0");
            }

            //Session["UserId"] = 1;
            //int userId = (int)Session["UserId"];
            //int id = Convert.ToInt32(Session["UserId"]);
            

        }

        public JsonResult Get()
        {

            try
            {

                    List<Item> Wishlist = (List<Item>)Session["Wishlist"];
                    

                return Json(Wishlist);
            }
            catch (Exception ex)
            {
                return Json("0");
            }


        }
        
	}

	}
