using MongoDbCRUD.Models; // Importing the models namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDbCRUD.Models.Respository; // Importing the repository for MongoDB

namespace MongoDbCRUD.Controllers
{
    public class ProductController : Controller
    {
        private TestCollection dbTest = new TestCollection(); // Creating an instance of the TestCollection repository

        public ActionResult Index()
        {
            return View(); // Returns the default view for the Index action.
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            dbTest.InsertTest(null); // Calls the InsertTest method to create a new test (null indicates it might need some parameters)

            return RedirectToAction("Index"); // Redirects to the Index action.
        }
    }
}
