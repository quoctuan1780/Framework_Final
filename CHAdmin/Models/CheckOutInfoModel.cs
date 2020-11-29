using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHAdmin.Models
{
    public class CheckOutInfoModel
    {
        [Display(Name = "Tên khách hàng")]
        [Required(ErrorMessage = "Yêu cầu nhập tên")]
        public string tenKH { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        public string diaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        public string sdt { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập email")]
        public string gmail { get; set; }

        [Display(Name = "Giới tính")]
        public string gioitinh { get; set; }

        [Display(Name = "Hình thức thanh toán")]
        public string httt { get; set; }

        [Display(Name = "Ghi chú")]
        public string ghichu { get; set; }
    }
}