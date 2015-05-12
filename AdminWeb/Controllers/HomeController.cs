using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWeb.Controllers
{
	[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "I be out! ";
            ViewData["Message"] = "Jeeee body!";
            ViewData["Strengur"] = "Djamm í kvöld...!";

            return View();
        }

    }
}