using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHAdmin.Models
{
    public class registerModel
    {
        [Key]
        public long id { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Yêu cầu nhập email")]
        public string email { set; get; }

        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "yêu cầu nhập tên tài khoản")]
        public string tentk { get; set; }

        [Display(Name = "Mật khẩu")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 kí tự")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu")]
        public string password { set; get; }

        [Display(Name = "xác nhận mật khẩu")]
        [Compare("password", ErrorMessage = "Mật khẩu nhập lại không đúng")]
        public string confirmpassword { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Yêu cầu nhập họ và tên")]
        public string hoten { get; set; }

        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "Yêu cầu nhập địa chỉ")]
        public string diachi { get; set; }

        [Display(Name = "Giới tính")]
        public string gioitinh { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Yêu cầu nhập số điện thoại")]
        public string sodt { get; set; }

        [Display(Name = "Hình ảnh")]
        public string hinhanh { get; set; }

    }
}