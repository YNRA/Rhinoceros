using System;
using System.IO;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Writer
{
    class Program
    {
        static void Main(string[] args)
        {
                var settings = "mongodb+srv://root:toor@rhinoceros.jkqed.mongodb.net/Rhinoceros?retryWrites=true&w=majority";
                var client = new MongoClient(settings);
                var Database = client.GetDatabase("Rhinoceros");

                var reader = new StreamReader(File.OpenRead(@"./population-francaise-par-departement-2018.csv")); 
                IMongoCollection<BsonDocument> csvFile = Database.GetCollection<BsonDocument>("Departments");

                reader.ReadLine(); 

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                        BsonDocument row = new BsonDocument
                        {
                            {"CodePostale", values[0]},
                            {"DepartmentNom", values[1]},
                            {"Population", values[2]},
                            {"GPS", values[3]}
                        };

                    csvFile.InsertOne(row);
                }
        }

    }
}

