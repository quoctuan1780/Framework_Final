using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CHAdmin.Models;
using Model.EF;

namespace CHAdmin.Areas.Client.Dao
{
    public class CheckOutDao
    {
        //private CoffeeHouseDbContext context = new CoffeeHouseDbContext();
        public int ThanhToan(List<cartModel> li, int makh, CheckOutInfoModel info)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                int madh;
                donhang dh = new donhang();
                //dh.khachhang = kh;
                dh.makh = makh;
                dh.ngaydat = DateTime.Today;
                dh.tongtien = cartModel.tongTien;
                dh.ghichu = info.ghichu;
                dh.httt = info.httt;
                dh.tttt = 0;
                ctx.donhangs.Add(dh);
                ctx.SaveChanges();
                //ma = dh.madh;
                //donhang temp = context.donhangs.Find(dh.madh);
                madh = (int)dh.madh;
                foreach (var sp in li)
                {
                    ctdh ct = new ctdh();
                    //ct.madh = ma;
                    /*ct.donhang = dh;*/
                    //ct.madh = temp.madh;
                    ct.madh = madh;
                    ct.masp = sp.maSP;
                    ct.soluong = sp.soLuong;
                    ct.gia = sp.donGia;
                    ctx.ctdhs.Add(ct);
                    //context.SaveChanges();
                }

                //try
                //{
                //    context.SaveChanges();
                //}
                //catch (Exception exc)
                //{
                //    string message = exc.GetType().FullName + ": " + exc.Message;
                //}
                cartModel.tongSoHang = 0;
                cartModel.tongTien = 0;
                return ctx.SaveChanges();
            }
                //long ma;
                //khachhang kh = context.khachhangs.FirstOrDefault(x => x.makh == makh);
                //kh.diachi = info.diaChi;
                //kh.email = info.gmail;
                //kh.ghichu = info.ghichu;
                //kh.gioitinh = info.gioitinh;
                //kh.hoten = info.tenKH;
                //kh.sodt = info.sdt;
                //kh.matk = null;
                //context.khachhangs.Add(kh);
                //context.SaveChanges();
            //    int madh;
            //    donhang dh = new donhang();
            //    //dh.khachhang = kh;
            //    dh.makh = makh;
            //    dh.ngaydat = DateTime.Today;
            //    dh.tongtien = cartModel.tongTien;
            //    dh.ghichu = info.ghichu;
            //    dh.httt = info.httt;
            //    dh.tttt = 0;
            //    context.donhangs.Add(dh);
            //    context.SaveChanges();
            //    //ma = dh.madh;
            //    //donhang temp = context.donhangs.Find(dh.madh);
            //    madh = (int) dh.madh;
            //    foreach (var sp in li)
            //    {
            //        ctdh ct = new ctdh();
            //        //ct.madh = ma;
            //        /*ct.donhang = dh;*/
            //        //ct.madh = temp.madh;
            //        ct.madh = madh;
            //        ct.masp = sp.maSP;
            //        ct.soluong = sp.soLuong;
            //        ct.gia = sp.donGia;
            //        context.ctdhs.Add(ct);
            //        //context.SaveChanges();
            //    }
                
            //    //try
            //    //{
            //    //    context.SaveChanges();
            //    //}
            //    //catch (Exception exc)
            //    //{
            //    //    string message = exc.GetType().FullName + ": " + exc.Message;
            //    //}
            //    cartModel.tongSoHang = 0;
            //    cartModel.tongTien = 0;
            //return context.SaveChanges(); 
        }
        public void ThanhToanKoCoSan(List<cartModel> li, CheckOutInfoModel info)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                //long ma;
                khachhang kh = new khachhang();
                kh.diachi = info.diaChi;
                kh.email = info.gmail;
                kh.ghichu = null;
                kh.gioitinh = info.gioitinh;
                kh.hoten = info.tenKH;
                kh.sodt = info.sdt;
                kh.matk = null;
                ctx.khachhangs.Add(kh);
                ctx.SaveChanges();
                //ma = kh.makh;
                //khachhang temp = context.khachhangs.Find(kh.makh);

                donhang dh = new donhang();
                //dh.makh = ma;
                dh.khachhang = kh;
                //dh.makh = temp.makh;
                dh.ngaydat = DateTime.Today;
                dh.tongtien = cartModel.tongTien;
                dh.ghichu = null;
                dh.httt = info.httt;
                ctx.donhangs.Add(dh);
                ctx.SaveChanges();
                //ma = dh.madh;
                //donhang dhtemp = context.donhangs.Find(dh.madh);
                foreach (var sp in li)
                {
                    ctdh ct = new ctdh();
                    //ct.madh = ma;
                    ct.donhang = dh;
                    //ct.madh = dhtemp.madh;
                    ct.masp = sp.maSP;
                    ct.soluong = sp.soLuong;
                    ct.gia = sp.donGia;
                    ctx.ctdhs.Add(ct);
                    //context.SaveChanges();
                }
                ctx.SaveChanges();
                //try
                //{
                //    context.SaveChanges();
                //}
                //catch (Exception exc)
                //{
                //    string message = exc.GetType().FullName + ": " + exc.Message;
                //}
                cartModel.tongSoHang = 0;
                cartModel.tongTien = 0;
            }
                ////long ma;
                //khachhang kh = new khachhang();
                //kh.diachi = info.diaChi;
                //kh.email = info.gmail;
                //kh.ghichu = null;
                //kh.gioitinh = info.gioitinh;
                //kh.hoten = info.tenKH;
                //kh.sodt = info.sdt;
                //kh.matk = null;
                //context.khachhangs.Add(kh);
                //context.SaveChanges();
                ////ma = kh.makh;
                ////khachhang temp = context.khachhangs.Find(kh.makh);

                //donhang dh = new donhang();
                ////dh.makh = ma;
                //dh.khachhang = kh;
                ////dh.makh = temp.makh;
                //dh.ngaydat = DateTime.Today;
                //dh.tongtien = cartModel.tongTien;
                //dh.ghichu = null;
                //dh.httt = info.httt;
                //context.donhangs.Add(dh);
                //context.SaveChanges();
                ////ma = dh.madh;
                ////donhang dhtemp = context.donhangs.Find(dh.madh);
                //foreach (var sp in li)
                //{
                //    ctdh ct = new ctdh();
                //    //ct.madh = ma;
                //    ct.donhang = dh;
                //    //ct.madh = dhtemp.madh;
                //    ct.masp = sp.maSP;
                //    ct.soluong = sp.soLuong;
                //    ct.gia = sp.donGia;
                //    context.ctdhs.Add(ct);
                //    //context.SaveChanges();
                //}
                //context.SaveChanges();
                ////try
                ////{
                ////    context.SaveChanges();
                ////}
                ////catch (Exception exc)
                ////{
                ////    string message = exc.GetType().FullName + ": " + exc.Message;
                ////}
                //cartModel.tongSoHang = 0;
                //cartModel.tongTien = 0;
        }
    }
}