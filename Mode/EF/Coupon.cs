namespace Mode.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Coupon")]
    public partial class Coupon
    {
        [Key]
        public int id_coupon { get; set; }

        public int? id_khachhang { get; set; }

        [StringLength(150)]
        public string tencoupon { get; set; }

        public string lifetime { get; set; }

        public string thestart { get; set; }

        public string theend { get; set; }

        [StringLength(10)]
        public string discount { get; set; }

        [StringLength(50)]
        public string status { get; set; }

        public string Ma_Coupon { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
