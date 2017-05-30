using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TerjeSaetherWeb.Models;

namespace TerjeSaetherWeb.Controllers
{
    public class FrontPageBoxesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FrontPageBoxes
        public ActionResult Index()
        {
            return View(db.FrontPageBoxes.ToList());
        }

        // GET: FrontPageBoxes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontPageBox frontPageBox = db.FrontPageBoxes.Find(id);
            if (frontPageBox == null)
            {
                return HttpNotFound();
            }
            return View(frontPageBox);
        }

        // GET: FrontPageBoxes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FrontPageBoxes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content")] FrontPageBox frontPageBox)
        {
            if (ModelState.IsValid)
            {
                frontPageBox.Id = Guid.NewGuid();
                db.FrontPageBoxes.Add(frontPageBox);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(frontPageBox);
        }

        // GET: FrontPageBoxes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontPageBox frontPageBox = db.FrontPageBoxes.Find(id);
            if (frontPageBox == null)
            {
                return HttpNotFound();
            }
            return View(frontPageBox);
        }

        // POST: FrontPageBoxes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content")] FrontPageBox frontPageBox)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frontPageBox).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frontPageBox);
        }

        // GET: FrontPageBoxes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrontPageBox frontPageBox = db.FrontPageBoxes.Find(id);
            if (frontPageBox == null)
            {
                return HttpNotFound();
            }
            return View(frontPageBox);
        }

        // POST: FrontPageBoxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            FrontPageBox frontPageBox = db.FrontPageBoxes.Find(id);
            db.FrontPageBoxes.Remove(frontPageBox);
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
