// General
using System;
using System.Linq;
using System.Collections.Generic;

// Data Access
using wm.sqlsat.alt.da.keyvalue;
using wm.sqlsat.alt.da.documentdb;
using wm.sqlsat.alt.da.rel;

// Entities
using wm.sqlsat.alt.entity;

// Azure Table Storage
using Microsoft.WindowsAzure.Storage.Table;

namespace wm.sqlsat.alt.svc
{
    public class Facade : IFacade
    {

        public void InsertClassRoom(int number, int building, int floor, int capacity, string description)
        {
            KeyValueDA.CreateClassRooms(number, building, floor, capacity, description);
        }


        public System.Collections.Generic.List<entity.ClassRoomEntity> GetClassRooms()
        {
            return KeyValueDA.GetClassRooms();
        }


        public IEnumerable<ClassesEntity> GetStudentsDistribution()
        {
            var students = DocumentDA.GetStudents();
            var classRooms = KeyValueDA.GetClassRooms();

            var classes = RelationalDA.GetClasses();

            foreach (var item in classRooms) {
                yield return new ClassesEntity() { 
                    ClassRoom = classRooms.Where(x=> x.Number == item.Number).FirstOrDefault(),
                    Students = (from s in students where 
                                   (from c in classes where 
                               c.ClassRoom == item.Number select c.Student).Contains(s.id)
                               select s).ToList()

                };
            }
        }
    }
}
