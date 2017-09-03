using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Context;
using ProjectManagementApp.Entities;

namespace ProjectManagementApp.Controllers
{
    public class TasksController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Tasks
        public ActionResult Index()
        {
            return View(db.TasksContext.ToList());
        }

        public ActionResult GetTasksForProject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            };
            var userID = (int)Session["UserID"];
            IEnumerable<Tasks> tasks = db.TasksContext.Where(x => x.ProjectID == id);
            return View(tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.TasksContext.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // GET: Tasks/Create
        public ActionResult Create(int projectID)
        {
            Tasks task = new Tasks();
            task.ProjectID = projectID;
            return View("Create", task);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tasks task, [Bind(Include = "TaskID,ProjectID,UserID,Name,Description,HoursEstimation,Status,EndDate")] Tasks tasks)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            };

            if (ModelState.IsValid)
            {
                var userID = (int)Session["UserID"];

                tasks.ProjectID = task.ProjectID;
                tasks.UserID = userID;

                db.TasksContext.Add(tasks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tasks);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.TasksContext.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TaskID,ProjectID,UserID,Name,Description,HoursEstimation,Status,EndDate")] Tasks tasks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tasks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tasks);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tasks tasks = db.TasksContext.Find(id);
            if (tasks == null)
            {
                return HttpNotFound();
            }
            return View(tasks);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tasks tasks = db.TasksContext.Find(id);
            db.TasksContext.Remove(tasks);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
