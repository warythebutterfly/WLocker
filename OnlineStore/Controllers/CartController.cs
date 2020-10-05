using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using OnlineStore.Models;
using OnlineStore.Services;
namespace OnlineStore.Controllers
{
    public class CartController : Controller
    {

        public JsonResult Add(int ItemId, int Quantity)
        {

            try
            {
                CartService cartService = new CartService();
                ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
                var Item = db.Items.Where(a => a.ID == ItemId).FirstOrDefault();

                CartItem cartItem = cartService.ConvertToCartItem(Item, Quantity);

                if (Session["Cart"] == null)
                {

                    List<CartItem> CartItems = new List<CartItem>();
                    CartItems.Add(cartItem);

                    Session["Cart"] = CartItems;
                }
                else
                {
                    List<CartItem> CartItems = (List<CartItem>)Session["Cart"];
                    // if that item is already in the  cart

                    var check = CartItems.Where(a => a.ID == ItemId).FirstOrDefault();
                    if (check != null)
                    {
                        foreach (var item in CartItems)
                        {
                            if (item.ID == ItemId)
                            {
                                item.Quantity = item.Quantity + Quantity;
                            }
                        }
                        Session["Cart"] = CartItems;
                    }
                    else
                    {

                        CartItems.Add(cartItem);
                        Session["Cart"] = CartItems;
                    }
                }

                return Json(cartItem.Name);
            }
            catch (Exception ex)
            {
                return Json("0");
            }

            //Session["UserId"] = 1;
            //int userId = (int)Session["UserId"];
            //int id = Convert.ToInt32(Session["UserId"]);


        }

        public JsonResult Update(int cartId, int quantity)
        {

            try
            {
                CartService cartService = new CartService();
                ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
                var Item = db.Items.Where(a => a.ID == cartId).FirstOrDefault();

                CartItem cartItem = cartService.ConvertToCartItem(Item, quantity);

                if (Session["Cart"] == null)
                {

                    List<CartItem> CartItems = new List<CartItem>();
                    CartItems.Add(cartItem);

                    Session["Cart"] = CartItems;
                }
                else
                {
                    List<CartItem> CartItems = (List<CartItem>)Session["Cart"];
                    // if that item is already in the  cart

                    var check = CartItems.Where(a => a.ID == cartId).FirstOrDefault();
                    if (check != null)
                    {
                        foreach (var item in CartItems)
                        {
                            if (item.ID == cartId)
                            {
                                item.Quantity = quantity;
                            }
                        }
                        Session["Cart"] = CartItems;
                    }
                    else
                    {

                        CartItems.Add(cartItem);
                        Session["Cart"] = CartItems;
                    }
                }

                return Json(cartItem.Name);
            }
            catch (Exception ex)
            {
                return Json("0");
            }

            //Session["UserId"] = 1;
            //int userId = (int)Session["UserId"];
            //int id = Convert.ToInt32(Session["UserId"]);


        }

        public JsonResult Remove(int cartId)
        {

            try
            {

                CartService cartService = new CartService();
                ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
                var Item = db.Items.Where(a => a.ID == cartId).FirstOrDefault();

                CartItem cartItem = cartService.RemoveFromCart(Item);
                List<CartItem> CartItems = (List<CartItem>)Session["Cart"];


                CartItems.RemoveAll(x => x.ID == cartItem.ID);

                Session["Cart"] = CartItems;




                return Json(cartItem.Name);
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

                List<CartItem> CartItems = (List<CartItem>)Session["Cart"];

                if (CartItems == null)
                {
                    return Json("0");
                }

                return Json(CartItems);
            }
            catch (Exception ex)
            {
                return Json("0");
            }


        }

        public JsonResult GetQuantity(int ItemId, int Quantity)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var cat = db.Items.Where(a => a.ID == ItemId).FirstOrDefault();

            return Json(cat);
        }
    }


}