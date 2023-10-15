using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDbCRUD.Controllers
{
    public class HomeController : Controller
    {
        // This action returns the default "Index" view.
        public ActionResult Index()
        {
            return View();
        }

        // This action sets a message in the ViewBag and returns the "About" view.
        public ActionResult About()
        {
            ViewBag.Message = "This application allows you to take tests with a final evaluation.";

            return View();
        }

        // This action sets a message in the ViewBag and returns the "Contact" view.
        public ActionResult Contact()
        {
            ViewBag.Message = "Italo.sorbara@gmail.com";

            return View();
        }
    }
}
