using AdminWeb.DAL;
using AdminWeb.DAL.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb.Controllers
{
    public class TransactionController : Controller
    {
        private IAdminWebDal adminWebDB;

		public TransactionController()
        {
			this.adminWebDB = new AdminWebDal(new AdminWebDalDataContext());
        }
		
		// GET: Transaction
        public ActionResult Index()
        {
			var transactions = adminWebDB.GetAllTransactions();
			
			return View(transactions);
        }

        // GET: Transaction/Details/5
        public ActionResult Details(int id)
        {
			var transaction = adminWebDB.GetTransactionByID(id);
			
			return View(transaction);
        }
    }
}
