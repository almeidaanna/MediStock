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
    public class EquipmentRatingsController : Controller
    {
        private FIT5032_MediStockContainer db = new FIT5032_MediStockContainer();

        // GET: EquipmentRatings
        public ActionResult Index()
        {
            var equipmentRatings = db.EquipmentRatings.Include(e => e.Equipment).Include(e => e.Doctor);
            return View(equipmentRatings.ToList());
        }

        // GET: EquipmentRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentRating equipmentRating = db.EquipmentRatings.Find(id);
            if (equipmentRating == null)
            {
                return HttpNotFound();
            }
            return View(equipmentRating);
        } 

        // GET: EquipmentRatings/Create
        public ActionResult Create()
        {
            ViewBag.EquipmentId = new SelectList(db.Equipments, "Id", "equipment_name");
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "first_name");
            return View();
        }

        // POST: EquipmentRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,rating,comment,commentDate,EquipmentId,DoctorId")] EquipmentRating equipmentRating)
        {
            if (ModelState.IsValid)
            {
                db.EquipmentRatings.Add(equipmentRating);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EquipmentId = new SelectList(db.Equipments, "Id", "equipment_name", equipmentRating.EquipmentId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "first_name", equipmentRating.DoctorId);
            return View(equipmentRating);
        }

        // GET: EquipmentRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentRating equipmentRating = db.EquipmentRatings.Find(id);
            if (equipmentRating == null)
            {
                return HttpNotFound();
            }
            ViewBag.EquipmentId = new SelectList(db.Equipments, "Id", "equipment_name", equipmentRating.EquipmentId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "first_name", equipmentRating.DoctorId);
            return View(equipmentRating);
        }

        // POST: EquipmentRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,rating,comment,commentDate,EquipmentId,DoctorId")] EquipmentRating equipmentRating)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentRating).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EquipmentId = new SelectList(db.Equipments, "Id", "equipment_name", equipmentRating.EquipmentId);
            ViewBag.DoctorId = new SelectList(db.Doctors, "Id", "first_name", equipmentRating.DoctorId);
            return View(equipmentRating);
        }

        // GET: EquipmentRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentRating equipmentRating = db.EquipmentRatings.Find(id);
            if (equipmentRating == null)
            {
                return HttpNotFound();
            }
            return View(equipmentRating);
        }

        // POST: EquipmentRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipmentRating equipmentRating = db.EquipmentRatings.Find(id);
            db.EquipmentRatings.Remove(equipmentRating);
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
