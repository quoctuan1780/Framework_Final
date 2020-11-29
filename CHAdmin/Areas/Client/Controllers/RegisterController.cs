using CHAdmin.Areas.Client.Dao;
using CHAdmin.Models;
using Model.EF;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Client/Register
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(registerModel model)
        {
            if (ModelState.IsValid)
            {

                user u = new user();
                u.email = model.email;
                u.hinhanh = null;
                u.maquyen = 1;
                u.password = model.password;
                u.ttdn = 0;
                u.tentk = model.tentk;
                //u.id = (long)kh.makh;

                khachhang kh = new khachhang();
                kh.email = model.email;
                kh.gioitinh = model.gioitinh;
                kh.hoten = model.hoten;
                kh.matk = u.id;
                kh.diachi = model.diachi;
                kh.sodt = model.sodt;
                kh.ghichu = null;
                //kh.matk = u.id;
                //kh.makh = null;

                if (new RegisterDao().DangKi(u, kh))
                {
                    ViewBag.success = "Đăng kí thành công";
                    //return RedirectToAction("Client/Home/Index");
                    model = new registerModel();
                }
                else
                {
                    ViewBag.fail = "Đăng kí thất bại";
                    ModelState.AddModelError("", "Email đã tồn tại");
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}