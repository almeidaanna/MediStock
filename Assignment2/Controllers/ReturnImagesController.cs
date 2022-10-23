using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    [Authorize]
    public class ReturnImagesController : Controller
    {
        private ManageReturnModel db = new ManageReturnModel();

        // GET: ReturnImages
        public ActionResult Index()
        {
            return View(db.ReturnImages.ToList());
        }

        // GET: ReturnImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnImage returnImage = db.ReturnImages.Find(id);
            if (returnImage == null)
            {
                return HttpNotFound();
            }
            return View(returnImage);
        }

        // GET: ReturnImages/Create
        [Authorize(Roles = "Doctor")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReturnImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Doctor")]
        public ActionResult Create([Bind(Include = "Id,Name")] ReturnImage image, HttpPostedFileBase
postedFile)
        {
            ModelState.Clear();
            var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
            image.Path = myUniqueFileName;
            TryValidateModel(image);
            if (ModelState.IsValid)
            {
                string serverPath = Server.MapPath("~/Uploads/");
                string fileExtension = Path.GetExtension(postedFile.FileName);
                string filePath = image.Path + fileExtension;
                image.Path = filePath;
                postedFile.SaveAs(serverPath + image.Path);
                db.ReturnImages.Add(image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(image);
        }

        // GET: ReturnImages/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnImage returnImage = db.ReturnImages.Find(id);
            if (returnImage == null)
            {
                return HttpNotFound();
            }
            return View(returnImage);
        }

        // POST: ReturnImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Path,Name")] ReturnImage returnImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(returnImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(returnImage);
        }

        // GET: ReturnImages/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReturnImage returnImage = db.ReturnImages.Find(id);
            if (returnImage == null)
            {
                return HttpNotFound();
            }
            return View(returnImage);
        }

        // POST: ReturnImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            ReturnImage returnImage = db.ReturnImages.Find(id);
            db.ReturnImages.Remove(returnImage);
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
