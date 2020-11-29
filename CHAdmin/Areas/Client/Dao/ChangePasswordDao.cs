using CHAdmin.Common;
using CHAdmin.Models;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class ChangePasswordDao
    {
        //private CoffeeHouseDbContext context = new CoffeeHouseDbContext();
        public bool DoiMatKhau( ChangePassModel model)
        {

            using (var ctx = new CoffeeHouseDbContext())
            {
                string matkhau = Encrypt.MD5Hash(model.reNewPass);
                var query = (from u in ctx.users
                             join kh in ctx.khachhangs
                             on u.id equals kh.matk
                             where u.email == model.email && u.password == matkhau
                             select new
                             {
                                 idUser = u.id,
                                 idKH = kh.makh,
                                 tenKH = kh.hoten,
                                 email = kh.email
                             }).FirstOrDefault();
                if (query is null)
                {
                    user u = ctx.users.FirstOrDefault(x => x.email == model.email);
                    u.password = matkhau;
                    ctx.users.AddOrUpdate(u);
                    ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            //    string matkhau = Encrypt.MD5Hash(model.reNewPass);
            //var query = (from u in context.users
            //             join kh in context.khachhangs
            //             on u.id equals kh.matk
            //             where u.email == model.email && u.password == matkhau
            //             select new
            //             {
            //                 idUser = u.id,
            //                 idKH = kh.makh,
            //                 tenKH = kh.hoten,
            //                 email = kh.email
            //             }).FirstOrDefault();
            //if (query != null)
            //{
            //        user u = context.users.FirstOrDefault(x => x.email == model.email);
            //        u.password = matkhau;
            //        context.users.AddOrUpdate(u);
            //        context.SaveChanges();
            //        return true;
            //}
            //else
            //{
            //    return false;
            //}
            
        }
    }
}