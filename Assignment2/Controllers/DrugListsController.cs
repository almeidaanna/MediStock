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
    public class DrugListsController : Controller
    {
        private FIT5032_MediStockContainer db = new FIT5032_MediStockContainer();

        // GET: DrugLists
        public ActionResult Index()
        {
            var drugLists = db.DrugLists.Include(d => d.Drug);
            return View(drugLists.ToList());
        }

        // GET: DrugLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugList drugList = db.DrugLists.Find(id);
            if (drugList == null)
            {
                return HttpNotFound();
            }
            return View(drugList);
        }

        // GET: DrugLists/Create
        public ActionResult Create()
        {
            ViewBag.drug_Id = new SelectList(db.Drugs, "Id", "drug_name");
            return View();
        }

        // POST: DrugLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "drug_Id,owner_id,available_stock")] DrugList drugList)
        {
            if (ModelState.IsValid)
            {
                db.DrugLists.Add(drugList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.drug_Id = new SelectList(db.Drugs, "Id", "drug_name", drugList.drug_Id);
            return View(drugList);
        }

        // GET: DrugLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugList drugList = db.DrugLists.Find(id);
            if (drugList == null)
            {
                return HttpNotFound();
            }
            ViewBag.drug_Id = new SelectList(db.Drugs, "Id", "drug_name", drugList.drug_Id);
            return View(drugList);
        }

        // POST: DrugLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "drug_Id,owner_id,available_stock")] DrugList drugList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(drugList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.drug_Id = new SelectList(db.Drugs, "Id", "drug_name", drugList.drug_Id);
            return View(drugList);
        }

        // GET: DrugLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DrugList drugList = db.DrugLists.Find(id);
            if (drugList == null)
            {
                return HttpNotFound();
            }
            return View(drugList);
        }

        // POST: DrugLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DrugList drugList = db.DrugLists.Find(id);
            db.DrugLists.Remove(drugList);
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
