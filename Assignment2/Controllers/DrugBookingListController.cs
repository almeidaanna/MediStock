using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class DrugBookingListController : Controller
    {
        // GET: DrugBookingList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DrugBookingListDetails()
        {
            return View();
        }
    }
}