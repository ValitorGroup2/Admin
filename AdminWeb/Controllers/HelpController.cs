using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb.Controllers
{
    [AllowAnonymous]
	public class HelpController : Controller
    {
        [AllowAnonymous]
		//
        // GET: /Help/
        public ActionResult Index()
        {
            return View();
        }
	}
}

