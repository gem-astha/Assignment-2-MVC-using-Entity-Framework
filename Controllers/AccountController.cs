using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCAss.Models;
using System.Web.Security;

namespace MVCAss.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Members model)
        {
            using (var context =new OfficeEntities())
            {
                bool isValid = context.Users1.Any(x=>x.UserName==model.UserName&&x.Password==model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Employee1");
                }
                ModelState.AddModelError("", "Invalid Username and Password");
                return View();
            }
            
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Users1 model)
        {
            using(var context=new OfficeEntities())
            {
                context.Users1.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}