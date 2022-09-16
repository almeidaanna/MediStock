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
    public class EquipmentListsController : Controller
    {
        private FIT5032_MediStockContainer db = new FIT5032_MediStockContainer();

        // GET: EquipmentLists
        public ActionResult Index()
        {
            var equipmentLists = db.EquipmentLists.Include(e => e.Equipment).Include(e => e.Doctor);
            return View(equipmentLists.ToList());
        }

        // GET: EquipmentLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentList equipmentList = db.EquipmentLists.Find(id);
            if (equipmentList == null)
            {
                return HttpNotFound();
            }
            return View(equipmentList);
        }

        // GET: EquipmentLists/Create
        public ActionResult Create()
        {
            ViewBag.equipment_id = new SelectList(db.Equipments, "Id", "equipment_name");
            ViewBag.owner_id = new SelectList(db.Doctors, "Id", "first_name");
            return View();
        }

        // POST: EquipmentLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "equipment_id,available_stock,owner_id")] EquipmentList equipmentList)
        {
            if (ModelState.IsValid)
            {
                db.EquipmentLists.Add(equipmentList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.equipment_id = new SelectList(db.Equipments, "Id", "equipment_name", equipmentList.equipment_id);
            ViewBag.owner_id = new SelectList(db.Doctors, "Id", "first_name", equipmentList.owner_id);
            return View(equipmentList);
        }

        // GET: EquipmentLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentList equipmentList = db.EquipmentLists.Find(id);
            if (equipmentList == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipment_id = new SelectList(db.Equipments, "Id", "equipment_name", equipmentList.equipment_id);
            ViewBag.owner_id = new SelectList(db.Doctors, "Id", "first_name", equipmentList.owner_id);
            return View(equipmentList);
        }

        // POST: EquipmentLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "equipment_id,available_stock,owner_id")] EquipmentList equipmentList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipmentList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipment_id = new SelectList(db.Equipments, "Id", "equipment_name", equipmentList.equipment_id);
            ViewBag.owner_id = new SelectList(db.Doctors, "Id", "first_name", equipmentList.owner_id);
            return View(equipmentList);
        }

        // GET: EquipmentLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EquipmentList equipmentList = db.EquipmentLists.Find(id);
            if (equipmentList == null)
            {
                return HttpNotFound();
            }
            return View(equipmentList);
        }

        // POST: EquipmentLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EquipmentList equipmentList = db.EquipmentLists.Find(id);
            db.EquipmentLists.Remove(equipmentList);
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
