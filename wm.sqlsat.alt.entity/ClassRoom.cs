using System;

// Azure Table Storage
using Microsoft.WindowsAzure.Storage.Table;

namespace wm.sqlsat.alt.entity
{
    public class ClassRoomEntity : TableEntity
    {
        public ClassRoomEntity(int number, int building)
        {
            this.PartitionKey = building.ToString();
            this.RowKey = number.ToString();

            Building = building;
            Number = number;
        }

        public ClassRoomEntity() { }
        public int Number { get; set; }
        public int Building { get; set; }
        public int Floor { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
    }
}
