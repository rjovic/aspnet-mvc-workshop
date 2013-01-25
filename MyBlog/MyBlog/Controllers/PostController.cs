using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    
    public class PostController : Controller
    {
        private MyBlogContext data = new MyBlogContext();

        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Post post)
        {
            if(!ModelState.IsValid)
            {
                return View(post);
            }

            var user = data.Users.FirstOrDefault(x => x.Username == User.Identity.Name);

            post.UserId = user.Id;
            post.CreatedOn = DateTime.Now;
            data.Posts.Add(post);
            data.SaveChanges();

            return RedirectToAction("Index", "Blog");

        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var post = data.Posts.FirstOrDefault(x => x.Id == id);
            if(post != null)
            {
                data.Posts.Remove(post);
                data.SaveChanges();
            }

            return RedirectToAction("Index", "Blog");
        }

        
        public ActionResult Details(int id)
        {
            var post = data.Posts.FirstOrDefault(x => x.Id == id);
            return View(post);
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            var post = data.Posts.FirstOrDefault(x => x.Id == id);
            return View(post);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(Post post)
        {
            data.Entry(post).State = EntityState.Modified;
            data.SaveChanges();

            return RedirectToAction("Index", "Blog");
        }

    }
}
