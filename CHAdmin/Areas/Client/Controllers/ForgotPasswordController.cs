using CHAdmin.Areas.Client.Dao;
using CHAdmin.Common;
using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class ForgotPasswordController : Controller
    {
        taikhoanDao taikhoanDao = new taikhoanDao();
        reminderDao reminderDao = new reminderDao();
        // GET: Client/ForgotPassword
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string mail)
        {
            string email = Request["email"] as string;
            bool kiemtrataikhoan = taikhoanDao.Kiemtrataikhoan(email);
            if (kiemtrataikhoan)
            {
                var user = taikhoanDao.getThongtintaikhoan(email);
                int id = (int)user.id;
                ViewData["thongbao"] = "ok";
                Random random = new Random();
                int kiemtramakp = reminderDao.setMakhoiphuc(id, Encrypt.MD5Hash(random.Next(1000, 2000).ToString()));
                if (kiemtramakp > 0)
                {
                    string code = reminderDao.getMakhoiphuc(id);
                    new forgotPasswordDao().sendMail(email, code);
                }
                else
                {
                    string code = reminderDao.getMakhoiphuc(id);
                    new forgotPasswordDao().sendMail(email, code);
                }
            }
            else ViewData["thongbao"] = "error";
            return View();
        }


        public ActionResult Khoiphucmatkhau(string code, string email)
        {
            ViewData["email"] = email;
            ViewData["maphuchoi"] = code;
            return View();
        }
        [HttpPost]
        public ActionResult Khoiphucmatkhau()
        {
            string code = Request["code"] as string;
            string email = Request["email_user"] as string;
            string matkhau = Request["password"] as string;
            string nhaplai = Request["re_password"] as string;
            var user = taikhoanDao.getThongtintaikhoan(email);
            int id = (int)user.id;
            if (!matkhau.Equals(nhaplai))
            {
                ViewData["thongbao"] = "error";
            }
            else
            {
                int ketqua = reminderDao.setKhoiphucthanhcong(id);
                if (ketqua > 0)
                {
                    taikhoanDao.postDoimatkhau(email, Encrypt.MD5Hash(matkhau));
                    ViewData["thongbao"] = "ok";
                    return View();
                }
                else ViewData["thongbao"] = "error_code";
            }
            return View();
        }
    }
}