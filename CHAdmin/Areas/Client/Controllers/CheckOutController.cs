using CHAdmin.Areas.Client.Dao;
using CHAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: Client/CheckOut
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(CheckOutInfoModel model)
        {
            if (ModelState.IsValid)
            {
                List<cartModel> li = Session["giohang"] as List<cartModel>;
                var id = Session["idKH"];
                //return Json(model);
                if (id == null)
                {
                    new CheckOutDao().ThanhToanKoCoSan(li, model);
                    ViewBag.success = "Đặt hàng thành công";
                    //CheckOutInfoModel md = new CheckOutInfoModel();
                }
                else
                {
                    int ketqua = new CheckOutDao().ThanhToan(li, (int)id, model);
                    if (ketqua > 0)
                        ViewBag.success = "Đặt hàng thành công";
                    else ViewBag.success = "Đặt hàng không thành công";
                    //CheckOutInfoModel md = new CheckOutInfoModel();
                }
                Session["giohang"] = null;
            }
            return View();
        }
    }
}