namespace Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThongKe")]
    public partial class ThongKe
    {
        [Key]
        public int id_thongke { get; set; }

        public DateTime? thoigian { get; set; }

        public int? sltonkho { get; set; }

        public int? slxuatkho { get; set; }

        public int? nvtongluong { get; set; }

        public int? nvungtruoc { get; set; }

        public int? nvtichcuc { get; set; }

        public double? tongchi { get; set; }

        public double? tongthu { get; set; }

        public double? doanhthu { get; set; }
    }
}
