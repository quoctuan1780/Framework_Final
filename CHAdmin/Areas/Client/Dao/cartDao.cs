using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CHAdmin.Models;

namespace CHAdmin.Areas.Client.Dao
{
    public class CartDao
    {
        public static List<cartModel> Them1SPVaoCart(int idSP, List<cartModel> li)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                var query = ctx.sanphams.Where(x => x.masp == idSP).FirstOrDefault();
                if (li.FirstOrDefault(x => x.maSP == idSP) != null)
                {
                    cartModel item = li.FirstOrDefault(x => x.maSP == idSP);
                    int index = li.IndexOf(item);
                    item.soLuong++;
                    cartModel.tongTien += item.donGia;
                    if (index != -1) li[index] = item;
                    return li;
                }
                else
                {
                    cartModel cart = new cartModel();
                    cart.maSP = (int)query.masp;
                    cart.tenSP = query.tensp;
                    cart.Hinh = query.hinhanh;
                    cart.donGiaKM = (int)query.giakm;
                    cart.donGiaGoc = (int)query.gia;
                    if (query.giakm != 0)
                    {
                        cart.donGia = (int)query.giakm;
                    }
                    else
                    {
                        cart.donGia = (int)query.gia;
                    }
                    cart.soLuong = 1;
                    cartModel.tongTien += cart.donGia;
                    cartModel.tongSoHang += 1;
                    li.Add(cart);
                    return li;
                }
            }
            //var query = new CoffeeHouseDbContext().sanphams.Where(x => x.masp == idSP).FirstOrDefault();
        }

        public static List<cartModel> ThemNSPVaoCart(int id, List<cartModel> li, int sl)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                var query = ctx.sanphams.Where(x => x.masp == id).FirstOrDefault();
                if (li.FirstOrDefault(x => x.maSP == id) != null)
                {
                    cartModel item = li.FirstOrDefault(x => x.maSP == id);
                    item.soLuong += sl;
                    cartModel.tongTien += item.donGia * sl;
                    //return "ok";
                    return li;
                }
                else
                {
                    cartModel cart = new cartModel();
                    cart.maSP = (int)query.masp;
                    cart.tenSP = query.tensp;
                    cart.Hinh = query.hinhanh;
                    cart.donGiaKM = (int)query.giakm;
                    cart.donGiaGoc = (int)query.gia;
                    if (query.giakm != 0)
                    {
                        cart.donGia = (int)query.giakm;
                    }
                    else
                    {
                        cart.donGia = (int)query.gia;
                    }
                    cart.soLuong = sl;
                    cartModel.tongTien += cart.donGia * sl;
                    cartModel.tongSoHang += sl;
                    li.Add(cart);
                    //return "ok";
                    return li;
                }
            }
            //    var query = new CoffeeHouseDbContext().sanphams.Where(x => x.masp == id).FirstOrDefault();
            //if (li.FirstOrDefault(x => x.maSP == id) != null)
            //{
            //    cartModel item = li.FirstOrDefault(x => x.maSP == id);
            //    item.soLuong += sl;
            //    cartModel.tongTien += item.donGia * sl;
            //    //return "ok";
            //    return li;
            //}
            //else
            //{
            //    cartModel cart = new cartModel();
            //    cart.maSP = (int)query.masp;
            //    cart.tenSP = query.tensp;
            //    cart.Hinh = query.hinhanh;
            //    cart.donGiaKM = (int)query.giakm;
            //    cart.donGiaGoc = (int)query.gia;
            //    if (query.giakm != 0)
            //    {
            //        cart.donGia = (int)query.giakm;
            //    }
            //    else
            //    {
            //        cart.donGia = (int)query.gia;
            //    }
            //    cart.soLuong = sl;
            //    cartModel.tongTien += cart.donGia * sl;
            //    cartModel.tongSoHang += sl;
            //    li.Add(cart);
            //    //return "ok";
            //    return li;
            //}
        }

        public static List<cartModel> SuaSoLuong(int id, int SLMoi, List<cartModel> li)
        {
            cartModel item = li.SingleOrDefault(x => x.maSP == id);
            int slcu = item.soLuong;
            if (item != null)
            {
                /*                cartModel.tongTien -= item.thanhTien;
                                cartModel.tongSoHang -= item.soLuong;
                                item.soLuong = SLMoi;
                                cartModel.tongTien += item.donGia;
                                cartModel.tongSoHang += item.soLuong;*/
                cartModel.tongTien -= item.donGia * slcu;
                cartModel.tongSoHang -= item.soLuong;
                item.soLuong -= slcu;
                item.soLuong += SLMoi;
                cartModel.tongSoHang += item.soLuong;
                cartModel.tongTien += item.soLuong * item.donGia;
            }
            return li;
        }

        public static List<cartModel> XoaSPTrongCart(int idSP, List<cartModel> li)
        {

            cartModel item = li.SingleOrDefault(x => x.maSP == idSP);
            if (item != null)
            {
                li.Remove(item);
                cartModel.tongTien -= item.thanhTien;
                cartModel.tongSoHang -= item.soLuong;
            }
            return li;
        }
    }
}