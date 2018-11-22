using MvcBootstrapBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Collections;

namespace MvcBootstrapBook.Controllers
{
    public class HomeController : Controller
    {
        static List<Task> gTasks = new List<Task>();
        TaskContext db = new TaskContext();

        //
        // GET: /Home/

        public ActionResult Index()
        {
          return View(db.Tasks);
        }

        //
        // GET: /Home/Details/5

        [HttpPost]
        public ActionResult Done(string taskId, FormCollection collection)
        {
          try 
          {
            gTasks[Int32.Parse(taskId)].IsCompleted = true;
          }
          catch
          {    }
          
          return RedirectToAction("Index");
        }

        //
        // GET: /Home/Create

        [HttpPost]
        public ActionResult Create(string taskText)
        {
          var task = new Task
          {
            Text = taskText,
            IsCompleted = false
          };

          gTasks.Add(task);

          return RedirectToAction("Index");
        }

        
        //
        // GET: /Home/Edit/5

        public ActionResult Edit(string taskId, string text)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(string taskId, string text, FormCollection collection)
        {
            try
            {
              gTasks[Int32.Parse(taskId)].Text = text;
            }
            catch
            { }
            
            return RedirectToAction("Index");
        }

        //
        // GET: /Home/Delete/5

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(string taskId, FormCollection collection)
        {
            try
            {              
                int idx = Int32.Parse(taskId);
                gTasks.RemoveAt(idx);
            }
            catch
            { }

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
          db.Dispose();
          base.Dispose(disposing);
        }
    }
}
