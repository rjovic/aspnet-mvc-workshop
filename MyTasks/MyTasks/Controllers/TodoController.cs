using MyTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyTasks.Controllers
{
    public class TodoController : Controller
    {
        private MyTasksEntities data = new MyTasksEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Todo todo)
        {
            data.Todo.Add(todo);
            data.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
