using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MongoDbCRUD.Models
{
    public class Test
    {
        // The ObjectId that uniquely identifies the test.
        [BsonId]
        public ObjectId Id { get; set; }

        // The name of the test. It's required and corresponds to the "TestName" in MongoDB.
        [Required]
        [BsonElement("TestName")]
        public string TestName { get; set; }

        // A list of questions associated with the test. It corresponds to the "Question" field in MongoDB.
        [Required]
        [BsonElement("Question")]
        public List<Question> Question { get; set; }

        // The selected test ID, which refers to another test.
        [BsonElement("selectedTestName")]
        public string SelectedTestId { get; set; }

        // The user's name associated with the test.
        [BsonElement("User")]
        public string User { get; set; }

        // The current question index (used for tracking the user's progress).
        [BsonElement("currentQuestionIndex")]
        public int currentQuestionIndex { get; set; }

        // The total number of questions in the test.
        [BsonElement("totalQuestions")]
        public int totalQuestions { get; set; }
    }
}
