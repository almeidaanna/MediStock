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
    public class EquipmentBookingsController : Controller
    {
        private FIT5032_MediStockContainer db = new FIT5032_MediStockContainer();

        // GET: EquipmentBookings
        public ActionResult Index()
        {
            var equipmentBookings = db.EquipmentBookings.Include(e => e.Doctor).Include(e => e.Logistic).Include(e => e.Equipment);
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
        public ActionResult Create(String date)
        {
            if (null == date)
                return RedirectToAction("Index");
            EquipmentBooking b = new EquipmentBooking();
            DateTime convertDate = DateTime.Parse(date);
            b.datetime = convertDate;
            return View(b);
        }

        // POST: EquipmentBookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,datetime,status,quantity,DoctorId,LogisticId,EquipmentId")] EquipmentBooking equipmentBooking)
        {
            var bookingsList = db.EquipmentBookings.ToList();
            foreach (EquipmentBooking a in bookingsList)
            {
                if (a.datetime == equipmentBooking.datetime)
                {
                    TempData["msg"] = "<script>alert('You have aready made a booking');</script>";
                    return RedirectToAction("Index");
                }
            }
            if (equipmentBooking.datetime >= DateTime.Today)
            {
                if (ModelState.IsValid)
                {
                    db.EquipmentBookings.Add(equipmentBooking);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            else
            {
                TempData["msg"] = "<script>alert('Please Book Equipments after current date');</script>";
                return RedirectToAction("Index");
            }

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
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "first_name", equipmentBooking.DoctorId);
            ViewBag.LogisticId = new SelectList(db.Logistics, "Id", "first_name", equipmentBooking.LogisticId);
            ViewBag.EquipmentId = new SelectList(db.Equipments, "Id", "equipment_name", equipmentBooking.EquipmentId);
            return View(equipmentBooking);
        }

        // POST: EquipmentBookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,datetime,status,quantity,DoctorId,LogisticId,EquipmentId")] EquipmentBooking equipmentBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "first_name", equipmentBooking.DoctorId);
            ViewBag.LogisticId = new SelectList(db.Logistics, "Id", "first_name", equipmentBooking.LogisticId);
            ViewBag.EquipmentId = new SelectList(db.Equipments, "Id", "equipment_name", equipmentBooking.EquipmentId);
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

                    return View();
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
