using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;
using Assignment2.Utils;

namespace Assignment2.Controllers
{
    public class DrugsController : Controller
    {
        private FIT5032_MediStockContainer db = new FIT5032_MediStockContainer();

        // GET: Drugs
        public ActionResult Index()
        {
            return View(db.Drugs.ToList());
        }

        // GET: Drugs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        // GET: Drugs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Drugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,drug_name,dosage,description,warning,side_effect")] Drug drug)
        {
            if (ModelState.IsValid)
            {
                db.Drugs.Add(drug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(drug);
        }

        // GET: Drugs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        // POST: Drugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,drug_name,dosage,description,warning,side_effect")] Drug drug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(drug);
        }

        // GET: Drugs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Drug drug = db.Drugs.Find(id);
            if (drug == null)
            {
                return HttpNotFound();
            }
            return View(drug);
        }

        // POST: Drugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Drug drug = db.Drugs.Find(id);
            db.Drugs.Remove(drug);
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
        //public ActionResult Details()
        //{
        //    return View(new SendEmailViewModel());
        //}

        [HttpPost]
        public ActionResult Details(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    EmailSender es = new EmailSender();
                    es.Send();

                    ViewBag.Result = "A mail has been sent to the logistics team and your registerd email-Id";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}
