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
    public class EquipmentBookingsController : Controller
    {
        private FIT5032_MediStockContainer db = new FIT5032_MediStockContainer();

        // GET: EquipmentBookings
        public ActionResult Index()
        {
            var equipmentBookings = db.EquipmentBookings.Include(e => e.Doctor).Include(e => e.Logistic).Include(e => e.EquipmentList);
            return View(equipmentBookings.ToList());
        }

        // GET: EquipmentBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentBooking equipmentBooking = db.EquipmentBookings.Find(id);
            if (equipmentBooking == null)
            {
                return HttpNotFound();
            }
            return View(equipmentBooking);
        }

        // GET: EquipmentBookings/Create
        public ActionResult Create()
        {
            ViewBag.sender_id = new SelectList(db.Doctors, "Id", "first_name");
            ViewBag.logistic_id = new SelectList(db.Logistics, "Id", "first_name");
            ViewBag.EquipmentList_equipment_id = new SelectList(db.EquipmentLists, "equipment_id", "equipment_id");
            return View();
        }

        // POST: EquipmentBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,receiver_id,datetime,delivery_status,transaction_status,quantity,sender_id,logistic_id,EquipmentList_equipment_id,EquipmentList_owner_id")] EquipmentBooking equipmentBooking)
        {
            if (ModelState.IsValid)
            {
                db.EquipmentBookings.Add(equipmentBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sender_id = new SelectList(db.Doctors, "Id", "first_name", equipmentBooking.sender_id);
            ViewBag.logistic_id = new SelectList(db.Logistics, "Id", "first_name", equipmentBooking.logistic_id);
            ViewBag.EquipmentList_equipment_id = new SelectList(db.EquipmentLists, "equipment_id", "equipment_id", equipmentBooking.EquipmentList_equipment_id);
            return View(equipmentBooking);
        }

        // GET: EquipmentBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentBooking equipmentBooking = db.EquipmentBookings.Find(id);
            if (equipmentBooking == null)
            {
                return HttpNotFound();
            }
            ViewBag.sender_id = new SelectList(db.Doctors, "Id", "first_name", equipmentBooking.sender_id);
            ViewBag.logistic_id = new SelectList(db.Logistics, "Id", "first_name", equipmentBooking.logistic_id);
            ViewBag.EquipmentList_equipment_id = new SelectList(db.EquipmentLists, "equipment_id", "equipment_id", equipmentBooking.EquipmentList_equipment_id);
            return View(equipmentBooking);
        }

        // POST: EquipmentBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,receiver_id,datetime,delivery_status,transaction_status,quantity,sender_id,logistic_id,EquipmentList_equipment_id,EquipmentList_owner_id")] EquipmentBooking equipmentBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sender_id = new SelectList(db.Doctors, "Id", "first_name", equipmentBooking.sender_id);
            ViewBag.logistic_id = new SelectList(db.Logistics, "Id", "first_name", equipmentBooking.logistic_id);
            ViewBag.EquipmentList_equipment_id = new SelectList(db.EquipmentLists, "equipment_id", "equipment_id", equipmentBooking.EquipmentList_equipment_id);
            return View(equipmentBooking);
        }

        // GET: EquipmentBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentBooking equipmentBooking = db.EquipmentBookings.Find(id);
            if (equipmentBooking == null)
            {
                return HttpNotFound();
            }
            return View(equipmentBooking);
        }

        // POST: EquipmentBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipmentBooking equipmentBooking = db.EquipmentBookings.Find(id);
            db.EquipmentBookings.Remove(equipmentBooking);
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
