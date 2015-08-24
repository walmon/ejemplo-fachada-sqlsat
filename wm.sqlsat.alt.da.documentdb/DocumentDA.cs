// General
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

// DocumentDB
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Azure.Documents;

// 
using wm.sqlsat.alt.entity;

namespace wm.sqlsat.alt.da.documentdb
{
    public class DocumentDA
    {
        // agrega aqui tus keys
        private static string endpointUrl =
            "";
        private static string authorizationKey =
            "";

        private static DocumentClient client = new DocumentClient(new Uri(endpointUrl), authorizationKey);

        public static IEnumerable<StudentEntity> GetStudents()
        {
            Database database = GetOrCreateDatabaseAsync("University").Result;

            //Create a document collection
            DocumentCollection documentCollection = GetOrCreateCollectionAsync(database.SelfLink, 
                "StudentsCollection").Result;

            var bornDate = DateTime.Today.AddYears(-20);

            foreach (var person in client.CreateDocumentQuery(documentCollection.DocumentsLink,
                "SELECT * FROM StudentsCollection f ")) {
                    yield return person;
            }
        }

        private static async Task<Database> GetOrCreateDatabaseAsync(string id)
        {
            Database database = client.CreateDatabaseQuery().Where(db => db.Id == id).ToArray().FirstOrDefault();
            if (database == null)
            {
                database = await client.CreateDatabaseAsync(new Database { Id = id });
            }

            return database;
        }

        private static async Task<DocumentCollection> GetOrCreateCollectionAsync(string dbLink, string id)
        {
            DocumentCollection collection = client.CreateDocumentCollectionQuery(dbLink).Where(c => c.Id == id).ToArray().FirstOrDefault();
            if (collection == null)
            {
                collection = await client.CreateDocumentCollectionAsync(dbLink, new DocumentCollection { Id = id });
            }

            return collection;
        } 
    }

    /* To create new students! 
     
     * //Create a database
            Database database = GetOrCreateDatabaseAsync("University").Result;

            //Create a document collection
            DocumentCollection documentCollection = GetOrCreateCollectionAsync(database.SelfLink, 
                "StudentsCollection").Result;

            var fooYears = -19;

            StudentEntity foo = new StudentEntity
            {
                Name = "Pedro",
                LastName = "Castro",
                BornDate = DateTime.Today.AddYears(fooYears),
                PhoneNumbers = new List<string>() { "22336644","50678985423" }
            };

            client.CreateDocumentAsync(documentCollection.DocumentsLink, foo);
     
     */

}
