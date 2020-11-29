using CHAdmin.Areas.Client.Dao;
using CHAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHAdmin.Areas.Client.Controllers
{
    public class CartController : Controller
    {

        // GET: Client/Cart
        public ActionResult Index()
        {
            List<cartModel> giohang = Session["giohang"] as List<cartModel>;
            return View(giohang);
        }

        public string Them1SP(int id)
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<cartModel>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }
            List<cartModel> giohang = Session["giohang"] as List<cartModel>;  // Gán qua biến giohang dễ code
            Session["giohang"]=CartDao.Them1SPVaoCart(id, giohang);
            return "ok";
        }

        public string ThemNSP(int id, int soluong)
        {
            if (Session["giohang"] == null) // Nếu giỏ hàng chưa được khởi tạo
            {
                Session["giohang"] = new List<cartModel>();  // Khởi tạo Session["giohang"] là 1 List<CartItem>
            }
            List<cartModel> giohang = Session["giohang"] as List<cartModel>;  // Gán qua biến giohang dễ code
            Session["giohang"] = CartDao.ThemNSPVaoCart(id, giohang, soluong);
            return "ok";
        }

        public int XoaSP(int id)
        {
            List<cartModel> li = Session["giohang"] as List<cartModel>;
            Session["giohang"] = CartDao.XoaSPTrongCart(id, li);
            return cartModel.TongTien;
        }

        public int SuaSL(int id, int soluong)
        {
            List<cartModel> li = Session["giohang"] as List<cartModel>;
            Session["giohang"] = CartDao.SuaSoLuong(id, soluong, li);
            return cartModel.tongTien;
        }

    }
}