using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wm.sqlsat.alt.da.rel
{
    public class RelationalDA
    {
        public static IEnumerable<Class> GetClasses() {
            sqlsat319Entities context = new sqlsat319Entities();
            return context.Classes;
        }
    }
}
