namespace Mode.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("History")]
    public partial class History
    {
        [Key]
        public int id_history { get; set; }

        [StringLength(50)]
        public string actions { get; set; }

        public DateTime? thoigian { get; set; }

        [StringLength(200)]
        public string tensanpham { get; set; }
    }
}
