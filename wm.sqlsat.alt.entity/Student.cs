using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wm.sqlsat.alt.entity
{
    public class StudentEntity
    {
        public Guid id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public List<string> PhoneNumbers { get; set; }
        public DateTime BornDate { get; set; }
    }
}
