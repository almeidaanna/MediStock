using Assignment2.Models;
using Assignment2.Utils;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    [RequireHttps]
    [Authorize]
    public class HomeController : Controller
    {
        private FIT5032_MediStockContainer db = new FIT5032_MediStockContainer();
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult HomePage()
        {
            if (User.IsInRole("Logistic"))
                return RedirectToAction("../EquipmentBookings/ViewBooking");
            ViewBag.Message = "Medistock Home Page";
            return View();
        }

        // GET: SendBulkEmails
        public ActionResult SendBulkEmail()
        {
            return View(new SendBulkEmailsViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SendBulkEmail(SendBulkEmailsViewModel model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var userId = User.Identity.GetUserId();
            IEnumerable<String> roleId = userManager.FindById(userId).Roles.Select(r => r.RoleId);
            List<string> UserList = new List<string>();
            try
            {
                int role_id = Convert.ToInt32(roleId.ElementAt(0));
                if (role_id == 2)
                {
                    var doctors = db.Doctors;
                    foreach (var i in doctors)
                    {
                        UserList.Add(i.email_address);
                    }
                }
                else if (roleId != null && roleId.GetEnumerator().MoveNext())
                {
                    var doctors = db.Doctors.Where(e => e.Id == role_id);
                    foreach (var i in doctors)
                    {
                        UserList.Add(i.email_address);
                    }
                }
                else
                {
                    return View("Index");
                }
                List<String> toEmail = UserList;
                if (ModelState.IsValid)
                {
                    try
                    {
                        String subject = model.Subject;
                        String contents = model.Contents;
                        BulkEmailSender es = new BulkEmailSender();
                        HttpPostedFileBase pathToFile = model.PathToFile;
                        es.Send(toEmail, subject, contents, pathToFile);

                        ViewBag.Result = "Email has been sent";
                        ModelState.Clear();
                        return View(new SendBulkEmailsViewModel());
                    }
                    catch
                    {
                        return View();
                    }
                }
                return View();
            }
            catch
            {
                return View("Index");
            }
        }
    }
}