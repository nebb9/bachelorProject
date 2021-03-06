﻿using System;
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
    public class SkillsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Skills
        public ActionResult Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            };
            var userID = (int)Session["UserID"];
            IEnumerable<Skills> skills = db.SkillsContext.Where(x => x.UserID == userID);

            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills.ToList());
        }

        //public ActionResult GetSkillsForUser()
        //{
        //    if (Session["UserID"] == null)
        //    {
        //        return RedirectToAction("Login", "Account");
        //    };

        //    var userID = (int)Session["UserID"];
        //    IEnumerable<Skills> skills = db.SkillsContext.Where(x => x.UserID == userID);

        //    if (skills == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(skills.ToList());
        //}

        // GET: Skills/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills skills = db.SkillsContext.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillID,UserID,Name,Level")] Skills skills)
        {
            if (ModelState.IsValid)
            {
                var userID = (int) Session["UserID"];
                skills.UserID = userID;
                db.SkillsContext.Add(skills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skills);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills skills = db.SkillsContext.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillID,UserID,Name")] Skills skills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(skills);
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Skills skills = db.SkillsContext.Find(id);
            if (skills == null)
            {
                return HttpNotFound();
            }
            return View(skills);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skills skills = db.SkillsContext.Find(id);
            db.SkillsContext.Remove(skills);
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
