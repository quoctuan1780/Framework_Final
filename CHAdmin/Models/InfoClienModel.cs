using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHAdmin.Models
{
    public class infoClientModel
    {
        public int idUser { get; set; }
        public int idKH { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ và tên")]
        public string hoten { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        public string diachi { get; set; }
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập số diện thoại")]
        public string sodt { get; set; }
        [Display(Name = "Giới tính")]
        public string gioitinh { get; set; }
        [Display(Name = "Tên tài khoản")]
        public string tenTk { get; set; }
    }
}