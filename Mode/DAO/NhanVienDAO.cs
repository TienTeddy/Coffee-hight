﻿using Mode.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class NhanVienDAO
    {
        Context_ db = null;
        public NhanVienDAO()
        {
            db = new Context_();
        }

        public List<NhanVien> GetNhanVien_All()
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.NhanViens.ToList();
        }
    }
}
