namespace Mode.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDon()
        {
            HoaDonCTs = new HashSet<HoaDonCT>();
        }

        [Key]
        public int id_hoadon { get; set; }

        public int? id_khachhang { get; set; }

        [StringLength(50)]
        public string thoigian { get; set; }

        public double tonggia { get; set; }

        public int? discount { get; set; }

        public double? diemcong { get; set; }

        public int soluong { get; set; }

        [StringLength(50)]
        public string trangthai { get; set; }

        public string tenkhachhang { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonCT> HoaDonCTs { get; set; }
    }
}
