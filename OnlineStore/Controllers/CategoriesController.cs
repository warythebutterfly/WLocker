using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineStore.Models;
namespace OnlineStore.Controllers
{
    public class CategoriesController : Controller
    {
        //
        // GET: /Categories/
        public ActionResult categories()
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            List<Category> catg = db.Categories.OrderBy(a => a.CategoryName).ToList();
            ViewModel vm = new ViewModel();
            vm.ctgry = catg;

            return View(vm);
        }

        [HttpGet]
        public ActionResult AddCategories()
        {
            return View();
        }

        [HttpPost]
        public string AddCategories(string cname)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            Category category = new Category();
            category.CategoryName = cname;

            db.Categories.Add(category);

            int count = db.SaveChanges();

            if (count > 0)
            {
                return "You have added a new category.";
            }
            else
            {
                return "An error occured.";

            }

        }

        [HttpGet]
        public ActionResult EditCategories(int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var user = db.Categories.Where(a => a.ID == id).FirstOrDefault();
            return View(user);
        }
        public ActionResult DeleteCategories(int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var user = db.Categories.Where(a => a.ID == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public string Update(string cname, int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            Category cat = db.Categories.Where(a => a.ID == id).FirstOrDefault();

            cat.CategoryName = cname;


            int count = db.SaveChanges();

            if (count > 0)
            {
                return "Updated Successfully! Press 'OK' to continue...";
            }
            else
            {
                return "An error occurred!";
            }

        }
        [HttpPost]
        public string Delete(int id)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var del = db.Categories.Where(a => a.ID == id).FirstOrDefault();

            db.Categories.Remove(del);
            int count = db.SaveChanges();

            if (count > 0)
            {
                return "Deleted Successfully! Press 'OK' to continue...";
            }
            else
            {
                return "An error occured!";
            }
        }

        public JsonResult GetCategory(int CategoryId)
        {
            ShopMgtSystemDBContext db = new ShopMgtSystemDBContext();
            var cat = db.Categories.Where(a => a.ID == CategoryId).FirstOrDefault();
            return Json(cat);
        }

       
	}
}