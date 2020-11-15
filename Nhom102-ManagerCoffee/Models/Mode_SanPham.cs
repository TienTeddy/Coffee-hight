using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nhom102_ManagerCoffee.Models
{
    public class Mode_SanPham
    {
        public int id_sanpham { get; set; }

        [StringLength(200)]
        public string tensanpham { get; set; }

        public int? id_loai { get; set; }

        public string hinhanh { get; set; }

        public double? gia { get; set; }

        public string mota { get; set; }

        public int? soluong { get; set; }
    }
}