using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.Controllers
{
    public class BlogController : Controller
    {
        private MyBlogContext data = new MyBlogContext();

        public ActionResult Index()
        {
            if(data.Users.Count() == 0)
            {
                return RedirectToAction("Create", "User");
            }

            var posts = data.Posts.ToList();
            return View(posts);
        }

    }
}
