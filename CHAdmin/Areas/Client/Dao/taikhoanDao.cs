using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class taikhoanDao
    {
        CoffeeHouseDbContext db = null;

        public taikhoanDao()
        {
            db = new CoffeeHouseDbContext();
        }
        public user getThongtintaikhoan(string userName)
        {
            return db.users.SingleOrDefault(x => x.email == userName);
        }

        public user Login(string userName, string password)
        {
            user result = null;
            result = db.users.Where(x => x.email == userName && x.password == password).FirstOrDefault();
            return result;
        }

        public void setTrangthaidangnhap(user taikhoan, int ttdn)
        {
            taikhoan.ttdn = ttdn;
            db.users.AddOrUpdate(taikhoan);
            db.SaveChanges();
        }

        public bool Kiemtramatkhau(string email, string matkhau)
        {
            var ketqua = db.users.Count(x => x.email == email && x.password == matkhau);
            if (ketqua > 0) return true;
            return false;
        }


        public bool Kiemtrataikhoan(string email)
        {
            int ketqua = db.users.Count(x => x.email == email);
            if (ketqua > 0) return true;
            return false;
        }


        public int postDoimatkhau(string email, string matkhau)
        {
            using (var db = new CoffeeHouseDbContext())
            {
                user us = db.users.Where(x => x.email == email).FirstOrDefault();
                us.password = matkhau;
                db.users.AddOrUpdate(us);
                return db.SaveChanges();
            }
        }
    }
}