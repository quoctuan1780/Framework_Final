using CHAdmin.Common;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class LoginDao
    {
        //private static CoffeeHouseDbContext context = new CoffeeHouseDbContext();
        public struct LoginUnit
        {
            public int idUser { get; set; }
            public int idKH { get; set; }
            public string tenKH { get; set; }
            public string email { get; set; }
        }
        public static List<LoginUnit> ClientLogin(string email, string password)
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                var f_password = Encrypt.MD5Hash(password);
                var query = (from u in ctx.users
                             join kh in ctx.khachhangs
                             on u.id equals kh.matk
                             where u.email == email && u.password == f_password
                             select new
                             {
                                 idUser = u.id,
                                 idKH = kh.makh,
                                 tenKH = kh.hoten,
                                 email = kh.email
                             }).FirstOrDefault();
                LoginUnit loginUnit = new LoginUnit();
                if (query != null)
                {
                    loginUnit.idUser = (int)query.idUser;
                    loginUnit.idKH = (int)query.idKH;
                    loginUnit.tenKH = query.tenKH;
                    loginUnit.email = query.email;
                }
                List<LoginUnit> li = new List<LoginUnit>();
                li.Add(loginUnit);
                return li;
            }
            //    var f_password = Encrypt.MD5Hash(password);
            //var query = (from u in context.users
            //             join kh in context.khachhangs
            //             on u.id equals kh.matk
            //             where u.email == email && u.password == f_password
            //             select new
            //             {
            //                 idUser = u.id,
            //                 idKH = kh.makh,
            //                 tenKH = kh.hoten,
            //                 email = kh.email
            //             }).FirstOrDefault();
            //LoginUnit loginUnit = new LoginUnit();
            //if (query != null)
            //{
            //    loginUnit.idUser = (int)query.idUser;
            //    loginUnit.idKH = (int)query.idKH;
            //    loginUnit.tenKH = query.tenKH;
            //    loginUnit.email = query.email;
            //}
            //List<LoginUnit> li = new List<LoginUnit>();
            //li.Add(loginUnit);
            //return li;
        }
    }
}