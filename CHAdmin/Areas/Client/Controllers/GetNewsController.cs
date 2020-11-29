using CHAdmin.Areas.Client.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class GetNewsController : Controller
    {
        // GET: Client/GetNews
        public ActionResult Index()
        {
            return View();
        }
        public string GetNews(string mail)
        {
            bool temp = new GetNewsDao().getDangkinhantin(mail);
            if(temp)
            return "ok";
            return "";
        }
    }
}