using CHAdmin.Areas.Client.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class DetailController : Controller
    {
        // GET: Client/Detail
        public ActionResult Index(int id)
        {
            DetailDao dao = new DetailDao();
            sanpham sp = dao.getDetail(id);
            ViewData["maloaisp"] = dao.getMaloaisanpham(id);
            return View(sp);
        }
    }
}