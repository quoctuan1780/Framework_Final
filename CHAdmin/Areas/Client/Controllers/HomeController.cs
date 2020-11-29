using CHAdmin.Areas.Client.Dao;
using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class HomeController : Controller
    {
        List<sanpham> spmoip;
        List<sanpham> spkhmp;
        public static int moi_index, km_index;

        public HomeController()
        {
            spmoip = HomeDao.getSPMoi();
            spkhmp = HomeDao.getSPKM();
        }
        // GET: Client/Home
        public ActionResult Index(int? page=1, int pageSize=8, string type=null)
        {
            switch (type)
            {
                case "spmoi":
                    moi_index = page.HasValue ? Convert.ToInt32(page) : 1;
                    break;
                case "spkm":
                    km_index = page.HasValue ? Convert.ToInt32(page) : 1;
                    break;
                default:
                    moi_index = page.HasValue ? Convert.ToInt32(page) : 1;
                    km_index = page.HasValue ? Convert.ToInt32(page) : 1;
                    break;
            }
            ViewBag.webgridData1 = spmoip.ToPagedList(moi_index, pageSize);
            ViewBag.webgridData2 = spkhmp.ToPagedList(km_index, pageSize);
            //var spmoip = HomeDao.getSPMoi().ToPagedList(page, pageSize);
            //var spkmp = HomeDao.getSPKM().ToPagedList(page, pageSize);
            //ViewData["spmoip"] = spmoip;
            //ViewData["spkmp"] = spmoip;
            return View();
        }
    }
}