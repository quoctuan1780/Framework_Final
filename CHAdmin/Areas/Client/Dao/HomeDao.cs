using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHAdmin.Areas.Client.Dao
{
    public class HomeDao
    {
        //private static CoffeeHouseDbContext context = new CoffeeHouseDbContext();

        public static List<sanpham> getSPMoi()
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                var query = ctx.sanphams.OrderBy(x => x.ngaynhap).ToList();
                return query;
            }
            //var query = context.sanphams.OrderBy(x => x.ngaynhap).ToList();
            //return query;
        }

        public static List<sanpham> getSPKM()
        {
            using (var ctx= new CoffeeHouseDbContext())
            {
                var query = ctx.sanphams.Where(x => x.giakm != 0).ToList();
                return query;
            }
            //var query = context.sanphams.Where(x => x.giakm != 0).ToList();
        }

        public static List<slide> getSlide()
        {
            using (var ctx = new CoffeeHouseDbContext())
            {
                var query = ctx.slides.ToList();
                return query;
            }
            //var query = context.slides.ToList();
            //return query;
        }

    }
}