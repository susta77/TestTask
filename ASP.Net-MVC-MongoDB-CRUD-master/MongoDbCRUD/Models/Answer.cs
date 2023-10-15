using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDbCRUD.Models
{
    public class Answer
    {
        [BsonElement("Text")]
        public string Text { get; set; }  // Stores the text of the answer

        [BsonElement("Correct")]
        public string Correct { get; set; }  // Indicates whether the answer is correct or not

        public bool Selected { get; set; }  // Represents if the answer has been selected by a user
    }
}
