using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CHAdmin
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Route admin
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Route tài khoản
            routes.MapRoute("Thongtintaikhoan",
                "Account/Thongtintaikhoan",
                new { controller = "Account", action = "Thongtintaikhoan" });

            routes.MapRoute("Danhsachtaikhoan",
                "Account/Danhsachtaikhoan",
                new { controller = "Account", action = "Danhsachtaikhoan" });

            routes.MapRoute("Dangxuat",
                "Account/Logout",
                new { controller = "Account", action = "Logout" });

            routes.MapRoute("Quanmatkhau",
                "Account/Quanmatkhau",
                new { controller = "Account", action = "Quenmatkhau"});

            routes.MapRoute("Suataikhoan",
                "Account/Suataikhoan/{email}",
                new { controller = "Account", action = "Suataikhoan", email = UrlParameter.Optional });

            //Route Ajax
            routes.MapRoute(
                "Loaikhachhang",
                "Ajax/getLoaikhachhang/{lkh}",
                new {controller = "Ajax", action = "getLoaikhachhang", lkh = UrlParameter.Optional }
                );

            routes.MapRoute(
                "Noidungphanhoi",
                "Ajax/getNoidungphanhoi/{maph}",
                new { controller = "Ajax", action = "getNoidungphanhoi", maph = UrlParameter.Optional }
                );

            //Route sản phẩm
            routes.MapRoute("Danhsachsanpham",
                "Sanpham/Danhsachsanpham",
                new { controller = "Sanpham", action = "Danhsachsanpham" }
                );

            routes.MapRoute("Themsanpham",
                "Sanpham/Themsanpham",
                new { controller = "Sanpham", action = "Themsanpham" }
                );

            routes.MapRoute("Suasanpham",
                "Sanpham/Suasanpham/{masp}",
                new { controller = "Sanpham", action = "Suasanpham", masp = UrlParameter.Optional }
                );
            routes.MapRoute("Xoasanpham",
                "Sanpham/Xoasanpham/{masp}",
                new { controller = "Sanpham", action = "Xoasanpham", masp = UrlParameter.Optional }
                );

            //Route loại sản phẩm
            routes.MapRoute("Danhsachloaisanpham",
                "Loaisanpham/Danhsachloaisanpham",
                new { controller = "Loaisanpham", action = "Danhsachloaisanpham" });

            routes.MapRoute("Themloaisanpham",
                "Loaisanpham/Themloaisanpham",
                new { controller = "Loaisanpham", action = "Themloaisanpham" });

            routes.MapRoute("Xoaloaisanpham",
                "Loaisanpham/Xoaloaisanpham/{maloaisp}",
                new { controller = "Loaisanpham", action = "Xoaloaisanpham", maloaisp = UrlParameter.Optional });

            routes.MapRoute("Sualoaisanpham",
                "Loaisanpham/Sualoaisanpham/{maloaisp}",
                new { controller = "Loaisanpham", action = "Sualoaisanpham", maloaisp = UrlParameter.Optional });
            //Route đơn hàng
            routes.MapRoute(
                "Danhsachdonhang",
                "Donhang/Danhsachdonhang",
                new { controller = "Donhang", action = "Danhsachdonhang" }
            );

            routes.MapRoute(
                "chitietdonhang",
                "Donhang/Chitietdonhang/{madh}",
                new { controller = "Donhang", action = "Chitietdonhang", madh = UrlParameter.Optional });

            routes.MapRoute(
                "donhangtheotrangthai",
                "Donhang/Donhangtheotrangthai/{tt}",
                new { controller = "Donhang", action = "Donhangtheotrangthai", tt = UrlParameter.Optional });

            routes.MapRoute(
                "Thanhtoandonhang",
                "Donhang/Thanhtoandonhang/{madh}",
                new { controller = "Donhang", action = "Thanhtoandonhang", madh = UrlParameter.Optional }
                );

            routes.MapRoute(
                "Xoadonhang",
                "Donhang/Xoadonhang/{madh}",
                new { controller = "Donhang", action = "Xoadonhang", madh = UrlParameter.Optional }
                );
            //Route Thống kê
            routes.MapRoute(
                "Doanhthutheosanpham",
                "Thongke/Doanhthutheosanpham/{nam}",
                new { controller = "Thongke", action = "Doanhthutheosanpham", nam = UrlParameter.Optional }
                );

            routes.MapRoute(
                "Doanhthutheohoadon",
                "Thongke/Doanhthutheohoadon/{date}/{value}",
                new { controller = "Thongke", action = "Doanhthutheohoadon", date = UrlParameter.Optional,value = UrlParameter.Optional  }
                );
            //Route Hóa đơn
            routes.MapRoute("Danhsachhoadon",
                "Hoadon/Danhsachhoadon",
                new { controller = "Hoadon", action = "Danhsachhoadon" });

            routes.MapRoute("Chitiethoadon",
                "Ajax/getChitiethoadon/{mahd}",
                new { controller = "Ajax", action = "getChitiethoadon", mahd = UrlParameter.Optional });

            //Route phản hồi
            routes.MapRoute("Danhsachphanhoi", 
                "Phanhoi/Danhsachphanhoi",
                new { controller = "Phanhoi", action = "Danhsachphanhoi" });

            routes.MapRoute("Xoaphanhoi",
                "Phanhoi/Xoaphanhoi/{maph}",
                new { controller = "Phanhoi", action = "Xoaphanhoi", maph = UrlParameter.Optional });

            //Route khách hàng
            routes.MapRoute(
                "Danhsachkhachhang",
                "Khachhang/Danhsachkhachhang",
                new {controller = "Khachhang", action = "Danhsachkhachhang"}
                );

            routes.MapRoute(
                "Dangkinhantinmoi",
                "Khachhang/Dangkinhantinmoi",
                new { controller = "Khachhang", action = "Dangkinhantinmoi" });

            routes.MapRoute(
                "Dangkinhantin",
                "Khachhang/Dangkinhantin",
                new { controller = "Khachhang", action = "Dangkinhantin" });

            //Route Trang chủ
            routes.MapRoute(
                "trangchu",
                "Admin/Index",
                new { controller = "Admin", action = "Index" });

            routes.MapRoute(
                name: "Default",
                url: "Client/{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "xoaspgiohang",
               "Client/{controller}/{action}",
               new { controller = "Cart", action = "XoaSP" });
            routes.MapRoute(
                name: "thaydoisoluong",
                "Client/{controller}/{action}/{id}/{soluong}",
                new { controller = "Cart", action = "SuaSL", id = "", soluong = "" });
            routes.MapRoute(
                name: "dangnhapclient",
                "Client/{controller}/{action}",
                new { controller = "Login", action = "Index" });
            routes.MapRoute(
                name: "dathang",
                "Client/{controller}/{action}",
                new { controller = "CheckOut", action = "Index" });
            routes.MapRoute(
                name: "capnhatthongtinkh",
                "Client/{controller}/{action}",
                new { controller = "ClientInfo", action = "Index" },
                new { httpMethod = new HttpMethodConstraint("POST") });
            routes.MapRoute(
                name: "dangxuatclient",
                url: "{area}/{controller}/{action}",
                new { area = "Client", controller = "Login", action = "Logout" });
            routes.MapRoute(
                name: "loaisanpham",
                "Client/{controller}/{action}/{id}",
                new { controller = "Product", action = "Index", id = "" });
            routes.MapRoute(
                name: "chitietsp",
                "Client/{controller}/{action}/{id}",
                new { controller = "Detail", action = "Index", id = "" });
            routes.MapRoute(
                name: "them1sp",
                "Client/{controller}/{action}/{id}",
                new { controller = "Cart", action = "Them1SP", id = "" });
            routes.MapRoute(
                name: "themnhieusp",
                "Client/{controller}/{action}/{id}/{sl}",
                new { controller = "Cart", action = "ThemNSP", id = "", sl = "" });
            routes.MapRoute(
                name: "trangchusp",
                "Client/{controller}/{action}",
                defaults: new { controller = "Home", action = "Index" });
            routes.MapRoute(
                name: "dangki",
                "Client/{controller}/{action}",
                new { controller = "Register", action = "DangKi" },
                new { httpMethod = new HttpMethodConstraint("POST") });

            routes.MapRoute(
                name:"dangkinhantinclient",
                "Client/{controller}/{GetNews}/{mail}",
                new {controller= "GetNews", action= "GetNews",mail="" }
                );
        }
    }
}
