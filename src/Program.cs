using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDB.Exemples
{

    class Program
    {
        private const string album_1 = @"{
            ""nome"": ""The Dark Side Of the Mon"",
            ""data"": ""29/04/1973""
        }";
        private const string album_3 = @"{
            ""nome"": ""Master of Puppets"",
            ""dataLancamento"": ""03/03/1986"",
            ""duracao"": ""3286""
        }";

        private const string album_4 = @"{
            ""nome"": ""...And Justice For All"",
            ""dataLancamento"": ""25/08/1988"",
            ""duracao"": ""3929""
        }";

        private const string album_5 = @"{
            ""nome"": ""Among the Living"",
            ""produtor"": ""Eddie Krammer""
        }";

        private const string album_6 = @"{
            ""nome"": ""Nervermind"",
            ""artista"": ""Nirvana"",
            ""estudioGravacao"": [
                ""Sound City Studios"",
                ""Smart Studios (Madison)""
            ],
            ""dataLancamento"": ""11/01/1992""
        }";

        private const string album_2 = @"{
            ""nome"": ""Reign in Blood"",
            ""artista"": ""Larry Carroll"",
            ""duracao"": ""1738"",
            ""dataLancamento"": ""07/10/1986""
        }";

        private const string album_7 = @"{
            ""nome"": ""Seventh Son of a Seventh Son"",
            ""artista"": ""Iron Maiden"",
            ""produtor"": ""Martin Birch"",
            ""dataLancamento"": ""11/04/1988"",
            ""estudioGravacao"": ""Music D Studios""
        }";

        static void Main(string[] args)
        {
            string[] str_array = { album_1, album_2, album_3, album_4, album_5, album_6, album_7 };

            var client = new MongoClient("mongodb://localhost:27017");
            var db = client.GetDatabase("aula_puc");

            db.DropCollection("albuns");
            db.CreateCollection("albuns");

            var collection = db.GetCollection<BsonDocument>("albuns");
            collection.Find<BsonDocument>(new BsonDocument()).ToList().ForEach(x => Console.WriteLine(x.ToString()));

            foreach (var item in str_array)
            {
                var doc = BsonDocument.Parse(item);
                collection.InsertOne(doc);
            }
        }
    }
}
