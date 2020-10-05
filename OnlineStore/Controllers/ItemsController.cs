using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models;
using System.IO;

namespace OnlineStore.Controllers
{
    public class ItemsController : Controller
    {
        //
        // GET: /Items/
        public ActionResult Item()
        {

            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            List<Item> item = db.Items.OrderBy(a => a.CategoryID).ToList();

            ViewModel vm = new ViewModel();
            vm.item = item;
            return View(vm);
        }
        public ActionResult AddItems()
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            ViewModel vm = new ViewModel();
            var listofcategories = db.Categories.ToList();
            vm.ctgry = listofcategories;
            return View(vm);
        }
        public ActionResult EditItems(int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var hut = db.Items.Where(a => a.ID == id).FirstOrDefault();
            ViewModel vm = new ViewModel();
            var listofcategories = db.Categories.ToList();
            vm.ctgry = listofcategories;
            vm.SingleItem = hut;
            return View(vm);
        }
        public ActionResult DeleteItems(int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var hut = db.Items.Where(a => a.ID == id).FirstOrDefault();
            return View(hut);
        }
        [HttpPost]
        public string Add(string name, decimal price, HttpPostedFileBase imageurl, string itemdesc, int catid, string available)
        {

            if (imageurl == null)
            {
                return "Please select an image!";
            }

            //set new upload location
            string location = Server.MapPath("~/Content/Images/");

            //generate folder if it doessnt exist
            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }

            //get file name
            var fileName = Path.GetFileName(imageurl.FileName);

            //get file extension
            string extension = Path.GetExtension(imageurl.FileName);

            //create unique file name
            string uniquefilename = Guid.NewGuid().ToString("N") + extension;

            //Combine location with image
            string fileinpath = Path.Combine(location + uniquefilename);

            //Store image
            imageurl.SaveAs(fileinpath);

            string dbpath = "/Content/Images/" + uniquefilename;

            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            Item item = new Item();
            item.Name = name;
            item.Price = price;
            item.ImageURL = dbpath;
            item.ItemDescription = itemdesc;
            item.CategoryID = catid;
            item.Availability = available;

            db.Items.Add(item);
            int count = db.SaveChanges();

            if (count > 0)
            {
                return "You have successfully added an item. Click 'OK' to continue...";
            }
            else
            {
                return "An error occured! Try again.";
            }
        }
        [HttpPost]
        public string Update(int id, string name, decimal price, HttpPostedFileBase imageurl, string itemdesc, int catid, string available)
        {

            if (imageurl == null)
            {
                return "Please select an image!";
            }

            //set new upload location
            string location = Server.MapPath("~/Content/Images/");

            //generate folder if it doessnt exist
            if (!Directory.Exists(location))
            {
                Directory.CreateDirectory(location);
            }

            //get file name
            var fileName = Path.GetFileName(imageurl.FileName);

            //get file extension
            string extension = Path.GetExtension(imageurl.FileName);

            //create unique file name
            string uniquefilename = Guid.NewGuid().ToString("N") + extension;

            //Combine location with image
            string fileinpath = Path.Combine(location + uniquefilename);

            //Store image
            imageurl.SaveAs(fileinpath);

            string dbpath = "/Content/Images/" + uniquefilename;


            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            Item item = db.Items.Where(a => a.ID == id).FirstOrDefault();



            item.Name = name;
            item.Price = price;
            item.ImageURL = dbpath;
            item.ItemDescription = itemdesc;
            item.CategoryID = catid;
            item.Availability = available;



            int count = db.SaveChanges();

            if (count > 0)
            {
                return "1";
            }
            else
            {
                return "An error occured. Please try again.";
            }

        }
        [HttpPost]
        public string Delete(int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            Item item = db.Items.Where(a => a.ID == id).FirstOrDefault();

            db.Items.Remove(item);
            int count = db.SaveChanges();
            if (count > 0)
            {
                return "You have deleted this item. Click 'OK' to continue...";
            }
            else
            {
                return "An error occured. Try again.";
            }
        }

        public JsonResult GetItem(int ItemId)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var cat = db.Items.Where(a => a.ID == ItemId).FirstOrDefault();
            return Json(cat);
        }

    }
}