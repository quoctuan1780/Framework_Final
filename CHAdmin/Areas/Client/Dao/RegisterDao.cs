using CHAdmin.Common;
using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class RegisterDao
    {

        //private CoffeeHouseDbContext context = new CoffeeHouseDbContext();
        public bool DangKi(user ur, khachhang kh)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                var check = ctx.users.Count(x => x.email == ur.email);
                if (check == 0)
                {
                    //ur.password = Encrypt.MD5Hash(ur.password);
                    //context.users.Add(ur);
                    //context.SaveChanges();
                    //user u = context.users.FirstOrDefault(s => s.id == ur.id);
                    //kh.user = u;
                    //context.khachhangs.Add(kh);
                    //context.SaveChanges();
                    ur.password = Encrypt.MD5Hash(ur.password);
                    ctx.users.Add(ur);
                    ctx.SaveChanges();
                    kh.matk = ctx.users.Where(u => u.email == ur.email).Select(u => u.id).First();
                    ctx.khachhangs.Add(kh);
                    ctx.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            //    var check = context.users.Count(x => x.email == ur.email);
            //if (check == 0)
            //{
            //    //ur.password = Encrypt.MD5Hash(ur.password);
            //    //context.users.Add(ur);
            //    //context.SaveChanges();
            //    //user u = context.users.FirstOrDefault(s => s.id == ur.id);
            //    //kh.user = u;
            //    //context.khachhangs.Add(kh);
            //    //context.SaveChanges();
            //    ur.password = Encrypt.MD5Hash(ur.password);
            //    context.users.Add(ur);
            //    context.SaveChanges();
            //    kh.matk = context.users.Where(u => u.email == ur.email).Select(u => u.id).First();
            //    context.khachhangs.Add(kh);
            //    context.SaveChanges();
            //    return true;
            //}
            //else
            //    return false;
        }
    }
}