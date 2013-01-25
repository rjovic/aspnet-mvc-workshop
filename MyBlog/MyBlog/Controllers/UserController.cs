using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyBlog.Controllers
{
    public class UserController : Controller
    {
        private MyBlogContext data = new MyBlogContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if(!ModelState.IsValid)
            {
                return View(user);
            }

            data.Users.Add(user);
            data.SaveChanges();

            return RedirectToAction("Index", "Blog");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var userInDb = data.Users.FirstOrDefault(x => x.Username == user.Username);

            if(user.Password == userInDb.Password)
            {
                FormsAuthentication.SetAuthCookie(user.Username, true);
                return RedirectToAction("Index", "Blog");
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Blog");
        }

    }
}
