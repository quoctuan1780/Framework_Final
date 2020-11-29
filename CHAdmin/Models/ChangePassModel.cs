using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHAdmin.Models
{
    public class ChangePassModel
    {
        [Display(Name ="Email")]
        [Required]
        public string email { get; set; }
        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage ="Yêu cầu nhập mật khẩu")]
        public string oldPass { get; set; }
        [Display(Name ="Mật khẩu mới")]
        [Required(ErrorMessage = "Yêu cầu nhập mật khẩu mới")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 kí tự")]
        public string newPass { get; set; }
        [Display(Name ="Nhập lại mật khẩu")]
        [Required(ErrorMessage = "Yêu cầu nhập lại mật khẩu mới")]
        [Compare("newPass", ErrorMessage = "Mật khẩu nhập lại không đúng")]
        public string reNewPass { get; set; }
    }
}