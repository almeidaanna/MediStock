using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class LogisticsController : Controller
    {
        private FIT5032_MediStockContainer db = new FIT5032_MediStockContainer();

        // GET: Logistics
        public ActionResult Index()
        {
            return View(db.Logistics.ToList());
        }

        // GET: Logistics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logistic logistic = db.Logistics.Find(id);
            if (logistic == null)
            {
                return HttpNotFound();
            }
            return View(logistic);
        }

        // GET: Logistics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logistics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,first_name,last_name,phone_no,email_id,password")] Logistic logistic)
        {
            if (ModelState.IsValid)
            {
                db.Logistics.Add(logistic);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(logistic);
        }

        // GET: Logistics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logistic logistic = db.Logistics.Find(id);
            if (logistic == null)
            {
                return HttpNotFound();
            }
            return View(logistic);
        }

        // POST: Logistics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,first_name,last_name,phone_no,email_id,password")] Logistic logistic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logistic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(logistic);
        }

        // GET: Logistics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logistic logistic = db.Logistics.Find(id);
            if (logistic == null)
            {
                return HttpNotFound();
            }
            return View(logistic);
        }

        // POST: Logistics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logistic logistic = db.Logistics.Find(id);
            db.Logistics.Remove(logistic);
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
