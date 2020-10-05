using OnlineStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Services
{
    public class CartService
    {
        public CartItem ConvertToCartItem(Item item, int Quantity)
        {
            CartItem cartItem = new CartItem();

            cartItem.Availability = item.Availability;
            cartItem.Name = item.Name;
            cartItem.Price = item.Price;
            cartItem.ID = item.ID;
            cartItem.ImageURL = item.ImageURL;
            cartItem.ItemDescription = item.ItemDescription;
            cartItem.DateAdded = item.DateAdded;
            cartItem.CategoryID = item.CategoryID;
            cartItem.Quantity = Quantity;

            return (cartItem);
        }
        public CartItem RemoveFromCart(Item item)
        {
            CartItem cartItem = new CartItem();

            cartItem.Availability = item.Availability;
            cartItem.Name = item.Name;
            cartItem.Price = item.Price;
            cartItem.ID = item.ID;
            cartItem.ImageURL = item.ImageURL;
            cartItem.ItemDescription = item.ItemDescription;
            cartItem.DateAdded = item.DateAdded;
            cartItem.CategoryID = item.CategoryID;
            //cartItem.Quantity = quantity;

            return (cartItem);
        }
    }
}