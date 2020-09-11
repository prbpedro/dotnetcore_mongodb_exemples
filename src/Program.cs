using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Exemples
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("aula_puc");

            db.DropCollection("albuns");
            db.CreateCollection("albuns");

            var collection = db.GetCollection<BsonDocument>("albuns");


            collection.Find<BsonDocument>(new BsonDocument()).ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
