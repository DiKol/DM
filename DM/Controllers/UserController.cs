using DataMart.Models.Users;
using DM.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DM.Controllers
{
    public class UserController : Controller
    {
            private UserDbContext db = new UserDbContext();

            public ActionResult Index()
            {
                return View(db.Users.ToList());
            }

            public ActionResult Create()
            {
                return PartialView();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Birth")] User user)
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Json(user);
                }
                return Json("Create error");
            }

            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return PartialView(user);
            }

            //POST: User/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Birth")] User user)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(user);
                }
                return Json("Edit error");
            }

            //GET: User/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return PartialView(user);
            }

            //POST: User/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                User myEntity = db.Users.Find(id);
                db.Users.Remove(myEntity);
                return Json(db.SaveChanges());
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