using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Nhom102_ManagerCoffee.Models
{
    public class Models_TaiKhoan
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id_taikhoan { get; set; }

        //[StringLength(15)]
        //public string loaitk { get; set; }

        [Required(ErrorMessage = "Please enter a UserName.")]
        [StringLength(50,MinimumLength =3)]
        //[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string taikhoan1 { get; set; }

        [Required(ErrorMessage ="Please enter a PassWord.")]
        [StringLength(50,MinimumLength =3)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$")]
        public string matkhau { get; set; }

        public bool checkbox { get; set; }
    }
}