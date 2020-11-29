using CHAdmin.Areas.Client.Dao;
using CHAdmin.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class ChangePassWordController : Controller
    {
        // GET: Client/ChangePassWord
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["idUser"] == null)
            {
                return Redirect("/Client/Login/Index");
            }
            else
            {
                //ViewBag.data = (int)Session["idUser"];
                ViewData["id"]= Session["idUser"]; 
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ChangePassModel model)
        {
            if (ModelState.IsValid)
            {

                if (new ChangePasswordDao().DoiMatKhau(model))
                {
                    using(var query = new CoffeeHouseDbContext())
                    {
                        user u = query.users.FirstOrDefault(x => x.email == model.email);
                        ViewData["id"] = u.id;
                    }
                    ViewBag.annoucement = "Đổi mật khẩu thành công";
                    model = new ChangePassModel();
                }
                else
                {
                    ViewBag.announcement = "Đổi mật khẩu không thành công";
                    ModelState.AddModelError("","Đổi mật khẩu không thành công");
                    //ChangePassModel change = new ChangePassModel();
                    return View();
                    //return Json(ViewData["id"]);
                }
            }
            //else
            //{
            //    return ModelState.Values.SelectMany(v => v.Errors);
            //}
            //return ModelState.IsValid;
            return View();
        }
    }
}