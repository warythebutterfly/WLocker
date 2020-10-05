using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var item = db.Items.OrderByDescending(a => a.DateAdded).Take(12).ToList();
            var item1 = db.Items.OrderBy(a => a.Price).Where(a => a.Price < 5000).Take(12).ToList();
            var item2 = db.Items.OrderByDescending(a => a.Price).Where(a => a.Price >= 10000).Take(12).ToList();
            ViewModel vm = new ViewModel();
            vm.item = item;
            vm.item1 = item1;
            vm.item2 = item2;
            return View(vm);
        }

        public ActionResult Product()
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var ctgry = db.Categories.OrderBy(a => a.CategoryName).ToList();

            var items = db.Items.OrderBy(a => a.CategoryID).Take(15).ToList();


            ViewModel vm = new ViewModel();

            vm.ctgry = ctgry;
            vm.item = items;
            vm.totalcount = db.Items.Count();

            return View(vm);
        }

        public ActionResult Filter()
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var ctgry = db.Categories.OrderBy(a => a.CategoryName).ToList();

            var items = db.Items.OrderBy(a => a.Price).Where(a => a.Price < 2000).ToList();


            ViewModel vm = new ViewModel();

            vm.ctgry = ctgry;
            vm.item = items;

            return View(vm);
        }

        public ActionResult ProductDetail(int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var hut = db.Items.Where(a => a.ID == id).FirstOrDefault();

            //category name
            var name = db.Categories.Where(a => a.ID == hut.CategoryID).FirstOrDefault();

            //Related Products
            var items = db.Items.Where(a => a.CategoryID == hut.CategoryID).ToList();


            ViewModel vm = new ViewModel();
            vm.SingleItem = hut;
            vm.SingleCategory = name;
            vm.item = items;
            return View(vm);
        }

        public ActionResult categoriespage(int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var list = db.Categories.OrderBy(a => a.CategoryName).ToList();
            var items = db.Items.Where(a => a.CategoryID == id).Take(15).ToList();

            ViewModel vm = new ViewModel();
            vm.ctgry = list;
            vm.item = items;
            vm.totalcount = db.Items.Where(a => a.CategoryID == id).Count();
            return View(vm);
        }

        public ActionResult Sale()
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var ctgry = db.Categories.OrderBy(a => a.CategoryName).ToList();
            var item = db.Items.OrderBy(a => a.Price).ToList();


            ViewModel vm = new ViewModel();
            vm.ctgry = ctgry;
            vm.item = item;
            return View(vm);
        }

        public ActionResult Cart()
        {
            ViewModel vm = new ViewModel();
            vm.CartItems = (List<CartItem>)Session["Cart"];

            decimal total = 0;

            if (vm.CartItems != null)
            {
                foreach (var item in vm.CartItems)
                {
                    total = total + (decimal)(item.Price * item.Quantity);
                }

            }

            vm.total = total;
            return View(vm);
        }

        public ActionResult Wishlist()
        {
            ViewModel vm = new ViewModel();
            vm.Wishlist = (List<Item>)Session["Wishlist"];

            decimal total = 0;

            if (vm.Wishlist != null)
            {
                foreach (var item in vm.Wishlist)
                {
                    total = total + (decimal)item.Price;
                }

            }

            vm.total = total;
            return View(vm);
        }

        public ActionResult Buy(int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var hut = db.Items.Where(a => a.ID == id).FirstOrDefault();

            //category name
            var name = db.Categories.Where(a => a.ID == hut.CategoryID).FirstOrDefault();

            //Related Products
            var items = db.Items.Where(a => a.CategoryID == hut.CategoryID).ToList();


            ViewModel vm = new ViewModel();
            vm.SingleItem = hut;
            vm.SingleCategory = name;
            vm.item = items;
            return View(vm);
        }

        public ActionResult Blog()
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var names = db.Categories.OrderBy(a => a.CategoryName).ToList();

            ViewModel vm = new ViewModel();
            vm.ctgry = names;
            return View(vm);
        }

        public ActionResult BlogDetail()
        {
            ViewModel vm = new ViewModel();
            return View(vm);
        }

        public ActionResult About()
        {
            ViewModel vm = new ViewModel();
            return View(vm);
        }

        public ActionResult Contact()
        {
            ViewModel vm = new ViewModel();
            return View(vm);
        }

        public ActionResult Account()
        {
            ViewModel vm = new ViewModel();
            return View(vm);
        }

        public ActionResult Dashboard()
        {
            if (Session["email"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }

        public string Login(string email, string password)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            AdminUser admin = db.AdminUsers.Where(a => a.Email == email && a.password == password).FirstOrDefault();

            if (admin != null)
            {
                Session["email"] = admin.Email;
                Session["UserId"] = admin.ID;
                return "1";
            }
            else
            {
                return "0";
            }
        }


    }
}