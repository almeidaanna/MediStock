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
    public class DrugBookingsController : Controller
    {
        private FIT5032_MediStockContainer db = new FIT5032_MediStockContainer();

        // GET: DrugBookings
        public ActionResult Index()
        {
            var drugBookings = db.DrugBookings.Include(d => d.Logistic).Include(d => d.DrugList);
            return View(drugBookings.ToList());
        }

        // GET: DrugBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugBooking drugBooking = db.DrugBookings.Find(id);
            if (drugBooking == null)
            {
                return HttpNotFound();
            }
            return View(drugBooking);
        }

        // GET: DrugBookings/Create
        public ActionResult Create()
        {
            ViewBag.logistic_id = new SelectList(db.Logistics, "Id", "first_name");
            ViewBag.DrugList_owner_id = new SelectList(db.DrugLists, "drug_Id", "drug_Id");
            return View();
        }

        // POST: DrugBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,sender_id,receiver_id,datetime,delivery_status,transaction_status,quantity,logistic_id,DrugList_owner_id,DrugList_drug_Id")] DrugBooking drugBooking)
        {
            if (ModelState.IsValid)
            {
                db.DrugBookings.Add(drugBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.logistic_id = new SelectList(db.Logistics, "Id", "first_name", drugBooking.logistic_id);
            ViewBag.DrugList_owner_id = new SelectList(db.DrugLists, "drug_Id", "drug_Id", drugBooking.DrugList_owner_id);
            return View(drugBooking);
        }

        // GET: DrugBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugBooking drugBooking = db.DrugBookings.Find(id);
            if (drugBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.logistic_id = new SelectList(db.Logistics, "Id", "first_name", drugBooking.logistic_id);
            ViewBag.DrugList_owner_id = new SelectList(db.DrugLists, "drug_Id", "drug_Id", drugBooking.DrugList_owner_id);
            return View(drugBooking);
        }

        // POST: DrugBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,sender_id,receiver_id,datetime,delivery_status,transaction_status,quantity,logistic_id,DrugList_owner_id,DrugList_drug_Id")] DrugBooking drugBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drugBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.logistic_id = new SelectList(db.Logistics, "Id", "first_name", drugBooking.logistic_id);
            ViewBag.DrugList_owner_id = new SelectList(db.DrugLists, "drug_Id", "drug_Id", drugBooking.DrugList_owner_id);
            return View(drugBooking);
        }

        // GET: DrugBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugBooking drugBooking = db.DrugBookings.Find(id);
            if (drugBooking == null)
            {
                return HttpNotFound();
            }
            return View(drugBooking);
        }

        // POST: DrugBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrugBooking drugBooking = db.DrugBookings.Find(id);
            db.DrugBookings.Remove(drugBooking);
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
