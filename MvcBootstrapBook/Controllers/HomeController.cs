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
        static int numObjects = 0;
        public HomeController()
        {
          numObjects++;
          Debug.WriteLine("!!!!!!! HomeController object created: {0}", numObjects);
        }

        static List<Task> gTasks = new List<Task>();

        static HomeController()
        {
          for (int i = 0; i < 5; i++)
          {
            var task = new Task
            {
              Text = "задача #" + i.ToString(),
              IsCompleted = false
            };

            gTasks.Add(task);
          }
        }

        //
        // GET: /Home/

        public ActionResult Index()
        {
          return View(gTasks);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Done(int idx)
        {
          gTasks[idx].IsCompleted = true;
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

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
