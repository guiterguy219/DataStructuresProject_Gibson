using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresProject_Gibson.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Exit()
        {
            return Redirect("https://www.byu.edu");
        }

    }
}