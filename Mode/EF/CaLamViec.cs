namespace Mode.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CaLamViec")]
    public partial class CaLamViec
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CaLamViec()
        {
            NhanViens = new HashSet<NhanVien>();
        }

        [Key]
        public int id_calamviec { get; set; }

        [StringLength(100)]
        public string tenca { get; set; }

        public DateTime? thoigianbatdau { get; set; }

        public DateTime? thoigianketthuc { get; set; }

        public double? luong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhanVien> NhanViens { get; set; }
    }
}
