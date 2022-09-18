using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }

        // GET: Registration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Registration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registration/Create
        [HttpPost]
        public ActionResult Create(RegistrationViewModel model)
        {
            try
            {
                // TODO: Add insert logic here
                String FirstName = model.FirstName;
                String LastName = model.LastName;
                String Email = model.Email;
                String Phone = model.Phone;
                String Password = model.Password;
                String ConfirmPassword = model.ConfirmPassword;
                String Role = model.Role;
                String MedicalRegistration = model.MedicalRegistration;
                String FacilityName = model.FacilityName;
                String Location = model.Location;
                ViewBag.FirstName = FirstName;
                ViewBag.LastName = LastName;
                ViewBag.Email = Email;
                ViewBag.Phone = Phone;
                ViewBag.Password = Password;
                ViewBag.ConfirmPassword = ConfirmPassword;
                ViewBag.Role = Role;
                ViewBag.MedicalRegistration = MedicalRegistration;
                ViewBag.FacilityName = FacilityName;
                ViewBag.Location = Location;
                return RedirectToAction("/Home/HomePage","HomePage");
                //return RedirectToAction("/Home/HomePage");
            }
            catch
            {
                return RedirectToAction("/Home/HomePage","HomePage");
                //return RedirectToAction("/Home/HomePage");
            }
        }

        // GET: Registration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Registration/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Registration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Registration/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}