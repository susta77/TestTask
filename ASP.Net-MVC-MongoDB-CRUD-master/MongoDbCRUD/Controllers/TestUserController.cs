using MongoDB.Driver;
using MongoDbCRUD.Models;
using MongoDbCRUD.Models.Respository;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MongoDbCRUD.Controllers
{
    public class TestUserController : Controller
    {
        private TestCollection dbTest = new TestCollection();
        private UserTestCollection dbUserTest = new UserTestCollection();

        public ActionResult Index()
        {
            // Return the default view.
            return View();
        }

        public ActionResult ViewTestUser(Test UserTest)
        {
            // Retrieve test data based on the provided test name.
            Test data = dbTest.GetAllTest().Where(x => x.TestName == UserTest.TestName).FirstOrDefault();

            if (data != null)
            {
                // If the test data is found, populate the user's test model with questions and ID.
                UserTest.Question = data.Question;
                UserTest.Id = data.Id;

                return View(UserTest);
            }
            else
            {
                // If no data is found, return the default view.
                return View();
            }
        }

        [HttpPost]
        public ActionResult EditTestUser(Test Test, FormCollection collection)
        {

            // Initialize an empty string to store detailed test information.
            string DetailInfoTest = "";

            // Create lists to store question names and answers.
            List<string> valueQuestionName = new List<string>();
            List<string> valueAnswer = new List<string>();

            // Iterate through the form collection to find question names.
            foreach (string key in collection.AllKeys.AsEnumerable().Where(x => x.Contains("QuestionName")))
            {
                // Add the question name to the list.
                valueQuestionName.Add(collection.GetValues(key).FirstOrDefault());
            }

            // Iterate through the form collection to find answers.
            foreach (string key in collection.AllKeys.AsEnumerable().Where(x => x == "Question"))
            {
                var isExist = collection.GetValues(key).FirstOrDefault();
                if (isExist != null)
                {
                    // Add the answers to the list.
                    valueAnswer = collection.GetValues(key).ToList<string>().ToList<string>();
                }
            }

            // Combine question names and answers into the DetailInfoTest string.
            for (int index = 0; index < valueQuestionName.Count; index++)
            {
                DetailInfoTest += $" {valueQuestionName[index]}  {valueAnswer[index]} ";
            }

            // Retrieve test data based on the provided test name.
            Test data = dbTest.GetAllTest().Where(x => x.TestName == Test.TestName).FirstOrDefault();

            // Calculate the count of correct answers.
            Int16.TryParse(collection.GetValues("Question").AsEnumerable().Where(x => x.ToLower().Contains("true")).Count().ToString(), out Int16 countCorrectAnswer);

            // Generate the result message.
            String result = $"Thank you, {Test.User}! You have answered correctly on {countCorrectAnswer} out of {data.Question.Count()} questions.";

            // Retrieve the UserTest object and update the result.
            UserTest objUserTest = dbUserTest.GetUserByUserName(Test.SelectedTestId, Test.User);
            objUserTest.Result = result;
            objUserTest.DetailInfoTest = DetailInfoTest;
            dbUserTest.UpdateUserTest(objUserTest.Id.ToString(), objUserTest);

            // Update the test data with the user's result and reset the current question index.
            data.User = objUserTest.Result;
            data.currentQuestionIndex = data.Question.Count();

            // Return the ViewTestUser view with updated data.
            return View("ViewTestUser", data);
        }
    }
}
