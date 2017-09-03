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
    public class AssignmentsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Assignments
        public ActionResult Index()
        {
            return View(db.AssignmentContext.ToList());
        }

        // GET: Assignments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.AssignmentContext.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // GET: Assignments/Create
        public ActionResult Create(int projectID)
        {
            Assignment assignment = new Assignment();
            assignment.ProjectID = projectID;
            return View("Create", assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Assignment a, [Bind(Include = "UserID")] Assignment assignment)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            };
           
            if (ModelState.IsValid)
            {
                var userID = (int)Session["UserID"];
                assignment.ProjectID = a.ProjectID;
                db.AssignmentContext.Add(assignment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignment);
        }

        // GET: Assignments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.AssignmentContext.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignmentID,ProjectID,UserID")] Assignment assignment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assignment);
        }

        // GET: Assignments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assignment assignment = db.AssignmentContext.Find(id);
            if (assignment == null)
            {
                return HttpNotFound();
            }
            return View(assignment);
        }

        // POST: Assignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assignment assignment = db.AssignmentContext.Find(id);
            db.AssignmentContext.Remove(assignment);
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
