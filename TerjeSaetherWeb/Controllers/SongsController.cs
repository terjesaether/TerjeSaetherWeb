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
    public class SongsController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private HelperMethods _helperMethods = new HelperMethods();

        // GET: Songs
        public ActionResult Index()
        {
            return View(_db.Song.ToList());
        }

        // GET: Songs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = _db.Song.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // GET: Songs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Comment,AudioUrl,ImageUrl,ShowOnFrontpage")] Song song)
        {
            //var request = HttpContext.Request;
            HttpRequest httpRequest = System.Web.HttpContext.Current.Request;
            var filePath = "/Audio";
            
            HttpPostedFile imageFile = null;
            HttpPostedFile audioFile = null;
           
            if (httpRequest.Files.Count > 0)
            {
                imageFile = httpRequest.Files[0];
                audioFile = httpRequest.Files[1];
            }
            

            if (ModelState.IsValid)
            {
                var filenames = new List<string> { song.Title };
                
                song.SongId = Guid.NewGuid();
                song.Timestamp = DateTime.Now;

                var imageId = Guid.NewGuid();
                song.Image = new Image
                {
                    ImageId = imageId,
                    Data = _helperMethods.ConvertToByteArray(imageFile.InputStream),
                    Timestamp = DateTime.Now,
                    ImageUrl = Url.RouteUrl("Images", new { id = imageId })
                };

                bool isSaved = _helperMethods.SaveUploadedAudioFile(audioFile, filePath, song.Title);

                if (isSaved)
                {
                    song.AudioUrl = filePath + song.Title;
                }

                _db.Song.Add(song);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(song);
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = _db.Song.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SongId,Title,Timestamp,AudioUrl")] Song song)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(song).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(song);
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Song song = _db.Song.Find(id);
            if (song == null)
            {
                return HttpNotFound();
            }
            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Song song = _db.Song.Find(id);
            _db.Song.Remove(song);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
