using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MongoDbCRUD.Models
{
    public class Question
    {
        [Required]
        [BsonElement("QuestionName")]
        public string QuestionName { get; set; }  // Stores the text of the question

        [BsonElement("Answer")]
        public List<Answer> Answer { get; set; }  // Contains a list of possible answers to the question
    }
}
