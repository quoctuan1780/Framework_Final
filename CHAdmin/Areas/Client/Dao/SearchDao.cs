using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class SearchDao
    {
        public List<sanpham> timKiem(string str)
        {
            using(var ctx=new CoffeeHouseDbContext())
            {
                return ctx.sanphams.Where(s =>s.tensp.Contains(str)==true).ToList();
            }
        }
    }
}