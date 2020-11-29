using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAdmin.Models
{
    public class cartModel
    {
        public string Hinh { get; set; }
        public int maSP { get; set; }
        public string tenSP { get; set; }
        public int donGia { get; set; }
        public int soLuong { get; set; }
        public int donGiaKM { get; set; }
        public int donGiaGoc { get; set; }
        public int thanhTien
        {
            get
            {
                return soLuong * donGia;
            }
        }

        public static int TongTien { get => tongTien; set => tongTien = value; }
        public static int TongSoHang { get => tongSoHang; set => tongSoHang = value; }

        public static int tongTien = 0;

        public static int tongSoHang = 0;
    }
}