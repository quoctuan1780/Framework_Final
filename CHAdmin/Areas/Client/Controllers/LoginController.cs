using CHAdmin.Areas.Client.Dao;
using CHAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Check()
        {
            if ((string)Session["thongbao"] == "ok")
            {
                return Redirect("/Client/Home/Index");
            }
            else
            {
                //return RedirectToAction("Index");
                return Redirect(Request.Headers["Referer"].ToString());
            }
        }
        // GET: Client/Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(loginModel loginModel)
        {
            var log = LoginDao.ClientLogin(loginModel.userName, loginModel.password).ToList();
            if (ModelState.IsValid)
            {
                if (log[0].email != null)
                {
                    ViewData["datalogin"] = log;
                    //add session
                    Session["tenKH"] = log[0].tenKH;
                    Session["email"] = log[0].email;
                    Session["idUser"] = (int)log[0].idUser;
                    Session["idKH"] = log[0].idKH;
                    Session["thongbao"] = "ok";
                    return RedirectToAction("Check");
                }
                else
                {
                    Session["thongbao"] = "fail";
                    ViewBag.error = "Login failed";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }


    }
}