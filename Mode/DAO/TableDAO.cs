using Mode.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class TableDAO
    {
        Context_ db = null;
        public TableDAO()
        {
            db = new Context_();
        }

        public List<dbo_Table> GetTable_show()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.dbo_Table.Where(x => x.int_out == "Chưa Rời Đi").ToList();
        }
    }
}
