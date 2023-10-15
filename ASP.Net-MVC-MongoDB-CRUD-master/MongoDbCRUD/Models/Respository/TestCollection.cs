using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDbCRUD.Models.Respository
{

    public class TestCollection
    {
        internal MongoDBRespository _repo = new MongoDBRespository();
        public IMongoCollection<Test> CollectionTest;

        public TestCollection()
        {
            this.CollectionTest = _repo.db.GetCollection<Test>("Test");
        }
        public List<Test> GetAllTest()
        {
            var queryTest = this.CollectionTest
                .Find(new BsonDocument())
                .ToListAsync();
            return queryTest.Result;
        }
        public void InsertTest(Test objTest)
        {
            objTest = InitializeTest("Geometry Test");
            Question objQuestion = AddQuestion("How many angles does a triangle have?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("How many angles does a square have?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("4", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("How many angles does a pentagon have?");
            objQuestion.Answer.Add(AddAnswer("5", "true"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("4", "false"));
            objQuestion.Answer.Add(AddAnswer("6", "false"));
            objQuestion.Answer.Add(AddAnswer("7", "false"));
            objQuestion.Answer.Add(AddAnswer("14", "false"));
            objQuestion.Answer.Add(AddAnswer("20", "false"));
            objQuestion.Answer.Add(AddAnswer("1", "false"));
            objQuestion.Answer.Add(AddAnswer("300", "false"));
            objQuestion.Answer.Add(AddAnswer("0", "false"));
            objQuestion.Answer.Add(AddAnswer("13", "false"));
            objQuestion.Answer.Add(AddAnswer("63", "false"));
            objTest.Question.Add(objQuestion);
            this.CollectionTest.InsertOneAsync(objTest);

            objTest = InitializeTest("Math Test");
            objQuestion = AddQuestion("What is 1+1?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("2", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 3+1?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("4", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 100*1?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("100", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 1%1?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("1", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 7*2?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("14", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 3+1000?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("1003", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 3-1?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("2", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 30+400?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("430", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 12%3?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("4", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 5+1?");
            objQuestion.Answer.Add(AddAnswer("5", "false"));
            objQuestion.Answer.Add(AddAnswer("3", "false"));
            objQuestion.Answer.Add(AddAnswer("6", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is 1000+1000?");
            objQuestion.Answer.Add(AddAnswer("500", "false"));
            objQuestion.Answer.Add(AddAnswer("39", "false"));
            objQuestion.Answer.Add(AddAnswer("2000", "true"));
            objTest.Question.Add(objQuestion);
            this.CollectionTest.InsertOneAsync(objTest);

            objTest = InitializeTest("Geography Test");
            objQuestion = AddQuestion("What is the capital of Italy?");
            objQuestion.Answer.Add(AddAnswer("Milan", "false"));
            objQuestion.Answer.Add(AddAnswer("Naples", "false"));
            objQuestion.Answer.Add(AddAnswer("Rome", "true"));
            objTest.Question.Add(objQuestion);

            objQuestion = AddQuestion("What is the capital of France?");
            objQuestion.Answer.Add(AddAnswer("Lyon", "false"));
            objQuestion.Answer.Add(AddAnswer("Marseille", "false"));
            objQuestion.Answer.Add(AddAnswer("Paris", "true"));
            objTest.Question.Add(objQuestion);


            objQuestion = AddQuestion("What is the capital of Spain?");
            objQuestion.Answer.Add(AddAnswer("Genoa", "false"));
            objQuestion.Answer.Add(AddAnswer("London", "false"));
            objQuestion.Answer.Add(AddAnswer("Barcelona", "false"));
            objQuestion.Answer.Add(AddAnswer("Bilbao", "false"));
            objQuestion.Answer.Add(AddAnswer("Madrid", "true"));
            objTest.Question.Add(objQuestion);

            this.CollectionTest.InsertOneAsync(objTest);

        }

        private Test InitializeTest(string TestName)
        {
            Test newTest = new Test();
            newTest.SelectedTestId = "";
            newTest.User = "";
            newTest.TestName = TestName;
            newTest.currentQuestionIndex = 0;
            newTest.totalQuestions = 0;
            newTest.Question = new List<Question>();
            return newTest;
        }
        private Question AddQuestion(string QuestionName)
        {
            Question objQuestion = new Question();
            objQuestion.QuestionName = QuestionName;
            objQuestion.Answer = new List<Answer>();
            return objQuestion;
        }
        private Answer AddAnswer(string AnswerValue, string correct)
        {
            Answer objAnswer = new Answer();
            objAnswer.Text = AnswerValue;
            objAnswer.Correct = $"{correct}-{AnswerValue}";
            return objAnswer;


        }
    }
}