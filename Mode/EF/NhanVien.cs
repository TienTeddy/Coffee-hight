namespace Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            dbo_Table = new HashSet<dbo_Table>();
        }

        [Key]
        public int id_nhanvien { get; set; }

        public int? id_taikhoan { get; set; }

        public int? id_calamviec { get; set; }

        [StringLength(50)]
        public string hoten { get; set; }

        [StringLength(10)]
        public string gioitinh { get; set; }

        [StringLength(250)]
        public string diachi { get; set; }

        public int? sdt { get; set; }

        public int? tonggiolam { get; set; }

        public double? tongtien { get; set; }

        public virtual CaLamViec CaLamViec { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<dbo_Table> dbo_Table { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
