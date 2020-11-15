namespace Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OutBill")]
    public partial class OutBill
    {
        [Key]
        public int id_outbill { get; set; }

        public DateTime? thoigian { get; set; }

        public int? id_sanpham { get; set; }

        public int? id_loai { get; set; }

        public int? id_khachhang { get; set; }

        [StringLength(200)]
        public string tensanpham { get; set; }

        [StringLength(200)]
        public string tenloai { get; set; }

        [StringLength(50)]
        public string trangthai { get; set; }

        public double? dongia { get; set; }

        public double? tonggia { get; set; }
    }
}
