using CHAdmin.Areas.Client.Dao;
using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class ContactController : Controller
    {
        // GET: Client/Contact
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string email, string subject, string message)
        {
            phanhoi ph = new phanhoi();
            ContactDao contactDao = new ContactDao();
            ph.email = email;
            ph.hoten = name;
            ph.ngayph = DateTime.Now.Date;
            ph.vande = subject;
            ph.noidung = message;
            int result = contactDao.postPhanHoi(ph);
            if(result > 0)
                ViewData["thongbao"] = "ok";
            return View();
        }
    }
}