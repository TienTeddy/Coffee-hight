namespace Mode
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TableCT")]
    public partial class TableCT
    {
        [Key]
        public int id_tablect { get; set; }

        public int? id_table { get; set; }

        [StringLength(200)]
        public string loaisanpham { get; set; }

        [StringLength(200)]
        public string tensanpham { get; set; }

        public double? gia { get; set; }

        public int? soluong { get; set; }

        public double? thanhtien { get; set; }

        public virtual dbo_Table dbo_Table { get; set; }
    }
}
