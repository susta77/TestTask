using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MongoDbCRUD.Models
{
    public class UserTest
    {
        [BsonId]
        public ObjectId Id { get; set; }  // Unique identifier for UserTest

        [BsonElement("TestId")]
        public string TestId { get; set; }  // Identifier for the associated test

        [BsonElement("UserId")]
        public string UserId { get; set; }  // Identifier for the user taking the test

        [Required]
        [BsonElement("Result")]
        public string Result { get; set; }  // Stores the test result for the user


        [Required]
        [BsonElement("DetailInfoTest")]
        public string DetailInfoTest { get; set; }  // Stores the test result for the user
    }
}
