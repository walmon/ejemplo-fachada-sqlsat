// General

using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using wm.sqlsat.alt.entity;
// Azure Table Storage

// Configuration

// Entities

namespace wm.sqlsat.alt.da.keyvalue
{
    public static class KeyValueDA
    {
        // agrega aqui tus keys
        static string accountName =
            "";
        static string accountKey =
            "";

        public static void CreateClassRooms(int number, int building, int floor, int capacity, string description)
        {
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);

            // Create the table client.
            CloudTableClient classRoomClient = storageAccount.CreateCloudTableClient();

            // Create the table if it doesn't exist.
            CloudTable table = classRoomClient.GetTableReference("ClassRoom");
            table.CreateIfNotExists();

            // Create the entity.
            ClassRoomEntity foo = new ClassRoomEntity(number, building);

            foo.Floor = floor;
            foo.Capacity = capacity;
            foo.Description = description;

            // Create the TableOperation that inserts the customer entity.
            TableOperation insertOperation = TableOperation.Insert(foo);

            // Execute the insert operation.
            table.Execute(insertOperation);
        }

        public static List<ClassRoomEntity> GetClassRooms() {
            StorageCredentials creds = new StorageCredentials(accountName, accountKey);
            CloudStorageAccount storageAccount = new CloudStorageAccount(creds, useHttps: true);


            // Create the table client.
            CloudTableClient classRoomClient = storageAccount.CreateCloudTableClient();

            // Create the table if it doesn't exist.
            CloudTable table = classRoomClient.GetTableReference("ClassRoom");
            table.CreateIfNotExists();

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<ClassRoomEntity> query = new TableQuery<ClassRoomEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "1"));

            // Print the fields for each customer.
            return table.ExecuteQuery(query).ToList();
        }
    }
}
