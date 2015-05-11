using AdminWeb.DAL;
using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AdminWeb.Controllers
{
    public class StaffController : Controller
    {
		private IAdminWebDal adminWebDB;
		private IAccountDal accountDB;

		public StaffController()
        {
			this.adminWebDB = new AdminWebDal(new AdminWebDalDataContext());
			this.accountDB = new AccountDal(new AccountDataContext());
        }
		
		// GET: Staff
        public ActionResult Index()
        {
			var allStaff = adminWebDB.GetAllStaff();
			
			return View(allStaff);
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(Staff staff)
        {
            try
            {
                // TODO: Add insert logic here
				// Muna að bæta við CompanyID og generate-a password og senda mail með upplýsingum
				var user = accountDB.GetUserByName(User.Identity.Name);

				staff.CompanyID = user.CompanyID;
				staff.Company = adminWebDB.GetCompanyByCompanyID(staff.CompanyID);
				
				System.Random RandNum = new System.Random();
				staff.Password = Convert.ToString(RandNum.Next(9999));

				adminWebDB.CreateStaff(staff);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/Edit/5
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

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/Delete/5
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
