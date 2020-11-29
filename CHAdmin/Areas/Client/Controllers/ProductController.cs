using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CHAdmin.Areas.Client.Dao;

namespace CHAdmin.Areas.Client.Controllers
{
    public class ProductController : Controller
    {
        // GET: Client/Product
        public ActionResult Index(int id)
        {
            ProductDao dao = new ProductDao();
            ViewData["cungloai"] = dao.getCungLoai(id);
            ViewData["ten"] = dao.getTenLoai(id);
            return View();
        }
    }
}