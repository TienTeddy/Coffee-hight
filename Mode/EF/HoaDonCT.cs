namespace Mode.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonCT")]
    public partial class HoaDonCT
    {
        [Key]
        public int id_hoadonct { get; set; }

        public int? id_hoadon { get; set; }

        public int? id_khachhang { get; set; }

        public int? id_sanpham { get; set; }

        public int? id_loai { get; set; }

        public int soluong { get; set; }

        public int? discount { get; set; }

        public double? dongia { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
