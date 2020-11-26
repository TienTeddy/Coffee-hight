namespace Mode.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("[dbo.Table]")]
    public partial class dbo_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public dbo_Table()
        {
            TableCTs = new HashSet<TableCT>();
        }

        [Key]
        public int id_table { get; set; }

        public int? id_nhanvien { get; set; }

        [StringLength(15)]
        public string tentable { get; set; }

        [StringLength(50)]
        public string null_full { get; set; }

        [StringLength(50)]
        public string yesbill_nobill { get; set; }

        public DateTime? thoigian { get; set; }

        [StringLength(50)]
        public string int_out { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TableCT> TableCTs { get; set; }
    }
}
