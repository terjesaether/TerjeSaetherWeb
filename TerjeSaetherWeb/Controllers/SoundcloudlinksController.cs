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
    public class SoundcloudlinksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Soundcloudlinks
        public ActionResult Index()
        {
            return View(db.Soundcloudlinks.ToList());
        }

        // GET: Soundcloudlinks/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soundcloudlink soundcloudlink = db.Soundcloudlinks.Find(id);
            if (soundcloudlink == null)
            {
                return HttpNotFound();
            }
            return View(soundcloudlink);
        }

        // GET: Soundcloudlinks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soundcloudlinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,Show")] Soundcloudlink soundcloudlink)
        {
            if (ModelState.IsValid)
            {
                soundcloudlink.Id = Guid.NewGuid();
                db.Soundcloudlinks.Add(soundcloudlink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soundcloudlink);
        }

        // GET: Soundcloudlinks/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soundcloudlink soundcloudlink = db.Soundcloudlinks.Find(id);
            if (soundcloudlink == null)
            {
                return HttpNotFound();
            }
            return View(soundcloudlink);
        }

        // POST: Soundcloudlinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Url,Show")] Soundcloudlink soundcloudlink)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soundcloudlink).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soundcloudlink);
        }

        // GET: Soundcloudlinks/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soundcloudlink soundcloudlink = db.Soundcloudlinks.Find(id);
            if (soundcloudlink == null)
            {
                return HttpNotFound();
            }
            return View(soundcloudlink);
        }

        // POST: Soundcloudlinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Soundcloudlink soundcloudlink = db.Soundcloudlinks.Find(id);
            db.Soundcloudlinks.Remove(soundcloudlink);
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
