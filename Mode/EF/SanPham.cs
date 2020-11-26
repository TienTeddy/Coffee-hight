namespace Mode.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            HoaDonCTs = new HashSet<HoaDonCT>();
        }

        [Key]
        public int id_sanpham { get; set; }

        [Required]
        [StringLength(200)]
        public string tensanpham { get; set; }

        public int? id_loai { get; set; }

        public string hinhanh { get; set; }

        public double? gia { get; set; }

        public string mota { get; set; }

        public int? soluong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonCT> HoaDonCTs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
