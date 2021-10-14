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
            // String line;
            // try
            // {
            //     StreamReader sr = new StreamReader("./depts2018.csv");
            //     line = sr.ReadLine();
            //     while (line != null)
            //     {
            //         Console.WriteLine(line);
            //         line = sr.ReadLine();
            //     }
            //     sr.Close();
            //     // Console.ReadLine();
            // }
            // catch(Exception e)
            // {
            //     Console.WriteLine("Exception: " + e.Message);
            // }
            // finally
            // {
            //     Console.WriteLine("Executing finally block.");
            // }
        // }
        // static void MongoDB(string[] args)
        // {
            // try
            // {
                // CONNECTION CLIENT MONGO
                var settings = "mongodb+srv://root:toor@rhinoceros.jkqed.mongodb.net/Rhinoceros?retryWrites=true&w=majority";
                var client = new MongoClient(settings);

                // LISTE DES DB
                // var dbList = client.ListDatabases().ToList();
                // Console.WriteLine("The list of databases on this server is: ");
                // foreach (var db in dbList)
                // {
                //     Console.WriteLine(db);
                // }

                // CONNECTION DB
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
                            {"Code_Postale", values[0]},
                            {"DepartmentNom", values[1]},
                            {"Population", values[2]},
                            {"GPS", values[3]}
                        };

                    csvFile.InsertOne(row);
                }

            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine("Error:" + ex.Message);
            // }


        }

    }
}

// Ajouter un ID incrementale, rajouter les try catch 
