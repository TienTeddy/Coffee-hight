using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mode.DAO
{
    public class TableCTDAO
    {
        Context_ db = null;
        public TableCTDAO()
        {
            db = new Context_();
        }

        public List<TableCT> GetTableCT_id(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            return db.TableCTs.Where(x => x.id_table == id).ToList();
        }

        public int PushTableCT(int[] data, int id_sanpham, int soluong)
        {
            int result = 0;
            for (int i = 0; i < data.Length; i++)
            {
                var sanpham = db.SanPhams.Find(id_sanpham);//get table_sanpham
                var loai = db.LoaiSanPhams.Find(sanpham.id_loai);//get table_loai

                var push = new TableCT()
                {
                    id_table = data[i],
                    loaisanpham = loai.tenloai,
                    tensanpham = sanpham.tensanpham,
                    gia = sanpham.gia,
                    soluong = soluong
                };
                db.TableCTs.Add(push);
                result = db.SaveChanges();
            }
            if (result > 0) return 1;
            else return 0;
        }
    }
}
