using CHAdmin.Areas.Client.Dao;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class SearchController : Controller
    {
        // GET: Client/Search
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int page = 1, int pageSize = 16)
        {
            string str = Request["s"] as string;
            ViewData["search"] = new SearchDao().timKiem(str).ToPagedList(page, pageSize);
            return View();
        }
    }
}