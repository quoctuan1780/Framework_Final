using CHAdmin.Areas.Client.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class IntroductController : Controller
    {
        // GET: Client/Introduct
        public ActionResult Index()
        {
            IntroductDao introductDao = new IntroductDao();
            ViewData["introduct"] = introductDao.getGioithieu();
            return View();
        }
    }
}