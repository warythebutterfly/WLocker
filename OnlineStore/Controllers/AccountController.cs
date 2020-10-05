using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using OnlineStore.Models;

namespace OnlineStore.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            if (Session["email"] != null)
            {
                return RedirectToAction("Dashboard", "Home");
            }
            else
            {
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Login", "Account");
        }

    }
}