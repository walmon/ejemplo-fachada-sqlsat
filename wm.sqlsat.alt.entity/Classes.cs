using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wm.sqlsat.alt.entity
{
    public class ClassesEntity
    {
        public ClassRoomEntity ClassRoom { get;set;}
        public List<StudentEntity> Students { get; set; }
    }
}
