using MongoDB.Bson;
using MongoDbCRUD.Models;
using MongoDbCRUD.Models.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDbCRUD.Controllers
{
    public class TestController : Controller
    {
        private TestCollection dbTest = new TestCollection();
        private UserTestCollection dbUserTest = new UserTestCollection();

        public ActionResult ViewTest()
        {
            // Retrieve a list of all tests and return the view.
            List<Test> data = dbTest.GetAllTest();
            return View(data);
        }

        // POST: Test/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // Handle the POST request for creating a user test.

                // Create a new UserTest object and set its properties from the form collection.
                UserTest objUsrTest = new UserTest();
                objUsrTest.UserId = collection.GetValue("UserName").AttemptedValue;
                objUsrTest.TestId = collection.GetValue("Id").AttemptedValue;

                // Insert the user test into the collection.
                dbUserTest.InsertUserTest(objUsrTest);

                // Convert the TestId to an ObjectId and retrieve the corresponding test.
                ObjectId objectId = new ObjectId(objUsrTest.TestId);
                Test objTest = dbTest.GetAllTest().Where(x => x.Id == objectId).FirstOrDefault();

                // Set the selected test and user on the Test object and redirect to the ViewTestUser action.
                objTest.SelectedTestId = objUsrTest.TestId;
                objTest.User = objUsrTest.UserId;

                return RedirectToAction("ViewTestUser", "TestUser", objTest);
            }
            catch
            {
                // Handle any exceptions by redirecting to the ViewTest action.
                return RedirectToAction("ViewTest");
            }
        }
    }
}
