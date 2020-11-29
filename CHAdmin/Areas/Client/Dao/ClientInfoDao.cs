using CHAdmin.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class ClientInfoDao
    {
        //private CoffeeHouseDbContext context = new CoffeeHouseDbContext();

        //public struct ClientInfoUnit
        //{
        //    public int idUser { get; set; }
        //    public int idKH { get; set; }
        //    public string tenKH { get; set; }
        //    public string email { get; set; }
        //    public string tenTK { get; set; }
        //    public string gioiTinh { get; set; }
        //    public string diaChi { get; set; }
        //    public string sdt { get; set; }
        //}
        public struct ItemUnit
        {
            public int makh { get; set; }
            public int madh { get; set; }
            public int masp { get; set; }
            public string tensp { get; set; }
            public string hinhsp { get; set; }
            public DateTime ngaydat { get; set; }
            public double tonggia { get; set; }
            public int soluong { get; set; }
            public double gia { get; set; }
        }
        public infoClientModel LoadInfo(int makh)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                var query = (from u in ctx.users
                             join kh in ctx.khachhangs
                             on u.id equals kh.matk
                             where kh.makh == makh
                             select new
                             {
                                 idUser = u.id,
                                 idKH = kh.makh,
                                 tenKH = kh.hoten,
                                 email = kh.email,
                                 tenTK = u.tentk,
                                 gioiTinh = kh.gioitinh,
                                 diaChi = kh.diachi,
                                 sdt = kh.sodt
                             }).FirstOrDefault();

                infoClientModel info = new infoClientModel();
                info.diachi = query.diaChi;
                info.email = query.email;
                info.gioitinh = query.gioiTinh;
                info.hoten = query.tenKH;
                info.sodt = query.sdt;
                info.tenTk = query.tenTK;
                info.idUser = (int)query.idUser;
                info.idKH = (int)query.idKH;
                return info;

                //ClientInfoUnit clientInfoUnit = new ClientInfoUnit();
                //clientInfoUnit.idUser = (int)query.idUser;
                //clientInfoUnit.idKH = (int)query.idKH;
                //clientInfoUnit.tenKH = query.tenKH;
                //clientInfoUnit.gioiTinh = query.gioiTinh;
                //clientInfoUnit.diaChi = query.diaChi;
                //clientInfoUnit.sdt = query.sdt;
                //return clientInfoUnit;
            }
            //    var query = (from u in context.users
            //             join kh in context.khachhangs
            //             on u.id equals kh.matk
            //             where kh.makh == makh
            //             select new
            //             {
            //                 idUser = u.id,
            //                 idKH = kh.makh,
            //                 tenKH = kh.hoten,
            //                 email = kh.email,
            //                 tenTK = u.tentk,
            //                 gioiTinh = kh.gioitinh,
            //                 diaChi = kh.diachi,
            //                 sdt = kh.sodt
            //             }).FirstOrDefault();

            //infoClientModel info = new infoClientModel();
            //info.diachi = query.diaChi;
            //info.email = query.email;
            //info.gioitinh = query.gioiTinh;
            //info.hoten = query.tenKH;
            //info.sodt = query.sdt;
            //info.tenTk = query.tenTK;
            //info.idUser = (int)query.idUser;
            //info.idKH = (int)query.idKH;
            //return info;

            ////ClientInfoUnit clientInfoUnit = new ClientInfoUnit();
            ////clientInfoUnit.idUser = (int)query.idUser;
            ////clientInfoUnit.idKH = (int)query.idKH;
            ////clientInfoUnit.tenKH = query.tenKH;
            ////clientInfoUnit.gioiTinh = query.gioiTinh;
            ////clientInfoUnit.diaChi = query.diaChi;
            ////clientInfoUnit.sdt = query.sdt;
            ////return clientInfoUnit;
        }

        public void ThayDoiInfo(infoClientModel info, int makh)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                khachhang kh = ctx.khachhangs.FirstOrDefault(x => x.makh == makh);
                if (kh != null)
                {
                    kh.sodt = info.sodt;
                    kh.diachi = info.diachi;
                    ctx.SaveChanges();
                }
                user u = ctx.users.FirstOrDefault(x => x.id == kh.matk);
                if (u != null)
                {
                    u.tentk = info.tenTk;
                    ctx.SaveChanges();
                }
            }
            //    khachhang kh = context.khachhangs.FirstOrDefault(x => x.makh == makh);
            //if (kh != null)
            //{
            //    kh.sodt = info.sodt;
            //    kh.diachi = info.diachi;
            //    context.SaveChanges();
            //}
            //user u = context.users.FirstOrDefault(x => x.id == kh.matk);
            //if (u != null)
            //{
            //    u.tentk = info.tenTk;
            //    context.SaveChanges();
            //}
        }

        public List<ItemUnit> getCtdhKhachHang(int id)
        {
            List<ItemUnit> li = new List<ItemUnit>();
            using(var ctx=new CoffeeHouseDbContext())
            {
                var query = (from dh in ctx.donhangs
                             join ct in ctx.ctdhs
                             on dh.madh equals ct.madh
                             join sp in ctx.sanphams
                             on ct.masp equals sp.masp
                             where dh.makh == id
                             orderby dh.ngaydat descending
                             select new { 
                                 makh=dh.makh,
                                 madh=dh.madh,
                                 tensp=sp.tensp,
                                 hinhsp=sp.hinhanh,
                                 ngaydat=dh.ngaydat,
                                 tonggia=ct.gia*ct.soluong,
                                 soluong=ct.soluong,
                                 masp=ct.masp,
                                 gia=ct.gia
                             }).ToList();
                foreach(var i in query)
                {
                    ItemUnit item = new ItemUnit();
                    item.soluong = i.soluong;
                    item.tensp = i.tensp;
                    item.tonggia = i.tonggia;
                    item.hinhsp = i.hinhsp;
                    item.madh = (int)i.madh;
                    item.masp = (int)i.masp;
                    item.gia = i.gia;
                    item.makh = (int)i.makh;
                    item.ngaydat = (DateTime)i.ngaydat;
                    li.Add(item);
                }
                return li;
            }
        }
    }
}