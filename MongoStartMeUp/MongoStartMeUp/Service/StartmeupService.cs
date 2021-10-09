using MongoDB.Bson;
using MongoDB.Driver;
using MongoStartMeUp.Models;
using MongoStartMeUp.Service.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoStartMeUp.Service
{
    public class StartmeupService
    {
        private readonly IMongoCollection<MyObject> _objects;
        public StartmeupService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("startmeup");

            _objects = database.GetCollection<MyObject>("namevalues");

        }

        public List<MyObject> Get(int page, int size)
        {
            List<MyObject> employees;
            employees = _objects.Find(emp => true).Skip(size * page).Limit(size).ToList();
            return employees;
        }
        public void Insert(MyObject obj)
        {
            _objects.InsertOne(obj);
        }
        public void Delete(MyObject obj)
        {
            _objects.DeleteOne(x => x.MongoId == obj.MongoId);
        }
        public void Update(MyObject obj)
        {
            var filter = Builders<MyObject>.Filter.Eq("MongoId", obj.MongoId);
            var updateDef = Builders<MyObject>.Update.Set("Value", obj.Value);
            var result = _objects.UpdateOne(filter, updateDef);

        }
        public void RandomGenerate()
        {
            for (int i = 0; i < 1000; i++)
            {
                var obj = new MyObject();
                obj.Name = "isim " + Guid.NewGuid();
                obj.Value = "value " + Guid.NewGuid();
                _objects.InsertOne(obj);
            }
        }

    }
}
