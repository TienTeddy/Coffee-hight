namespace Mode.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            Coupons = new HashSet<Coupon>();
            HoaDons = new HashSet<HoaDon>();
        }

        [Key]
        public int id_khachhang { get; set; }

        public int? id_taikhoan { get; set; }

        [StringLength(50)]
        public string hoten { get; set; }

        [StringLength(10)]
        public string gioitinh { get; set; }

        [StringLength(250)]
        public string diachi { get; set; }

        public int? sdt { get; set; }

        public double? diem { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Coupon> Coupons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
