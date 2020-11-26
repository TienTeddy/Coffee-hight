using Mode.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class LichSuDAO
    {
        Context_ db = null;
        public LichSuDAO()
        {
            db = new Context_();
        }

        public List<History> GetHistorie_All()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.Histories.ToList();
        }
    }
}
