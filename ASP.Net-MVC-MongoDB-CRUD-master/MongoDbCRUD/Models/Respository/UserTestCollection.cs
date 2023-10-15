using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoDbCRUD.Models.Respository
{
    public class UserTestCollection
    {
        // An instance of MongoDBRespository to access the database.
        internal MongoDBRespository _repo = new MongoDBRespository();

        // Collection for storing UserTest objects.
        public IMongoCollection<UserTest> CollectionUserTest;

        // Constructor that initializes the CollectionUserTest field.
        public UserTestCollection()
        {
            this.CollectionUserTest = _repo.db.GetCollection<UserTest>("UserTest");
        }

        // Inserts a UserTest object into the database.
        public void InsertUserTest(UserTest objUserTest)
        {
            this.CollectionUserTest.InsertOneAsync(objUserTest);
        }

        // Retrieves a UserTest object by testId and userName.
        public UserTest GetUserByUserName(string testId, string userName)
        {
            var userTest = this.CollectionUserTest.Find(
                new BsonDocument { { "TestId", testId }, { "UserId", userName } })
                .FirstOrDefaultAsync()
                .Result;
            return userTest;
        }

        // Updates a UserTest object with the specified id.
        public void UpdateUserTest(string id, UserTest objUserTest)
        {
            var filter = Builders<UserTest>
                .Filter
                .Eq(s => s.Id, new ObjectId(id));
            this.CollectionUserTest.ReplaceOneAsync(filter, objUserTest);
        }
    }
}
